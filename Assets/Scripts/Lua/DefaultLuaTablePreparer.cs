using System.Text;
using XLua;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Assets.Scripts.LuaIntegration
{
    public class DefaultLuaTablePreparer : ILuaTablePreparer
    {
        public void PrepareTable(LuaEnv luaEnv, LuaTable table, InjectableInLua injectedObject)
        {
            LuaTable meta = luaEnv.NewTable();
            ConfigureMetaTable(meta, luaEnv, injectedObject);
            table.SetMetaTable(meta);
            meta.Dispose();
            SetDefaultTableMembers(luaEnv, table);
            SetEnumsInTable(luaEnv, table, injectedObject);

            //   foreach (var en in Enum.GetNames(typeof(Assets.Scripts.LuaObjects.CheckEnum))) { }
            //    UnityEngine.Debug.Log(en);

            //  foreach (var en in Enum.GetNames(table.Get<LuaTable>("CheckEnum").Get<Type>("UnderlyingSystemType"))) { }
            //   UnityEngine.Debug.Log(en);

            //  foreach (var en in table.Get<LuaTable>("CheckEnum").GetKeys()) { }
            //    UnityEngine.Debug.Log(en);




            //  UnityEngine.Debug.Log(table.Get<LuaTable>("CheckEnum").Get<Type>("UnderlyingSystemType"));

            //foreach (var v in table.GetKeys())
            {
             //   UnityEngine.Debug.Log(v);
            }
        }
        private void ConfigureMetaTable(LuaTable meta, LuaEnv luaEnv, InjectableInLua injectedObject)
        {
            meta.Set("_G", luaEnv.Global);
            meta.Set("__scriptTable", injectedObject);

            string asyncCommands = GetAsyncFunctionsTableCode(injectedObject.Commands.Values.ToList());

            luaEnv.DoString(@"
            util = _G.require 'xlua.util'

            asyncTable = { 
                " + asyncCommands + @"
            }

            __index = function (table, key)
    
                if asyncTable[key] ~= nil then
                    return function(...) return asyncTable[key](__scriptTable, ...) end
                end

                if _G.type(__scriptTable[key]) == 'function' then 
                    return function (...) return __scriptTable[key](__scriptTable, ...) end
                end
                return __scriptTable[key]
            end", env: meta);
        }
        private string GetAsyncFunctionsTableCode(List<LuaCsCommand> commands)
        {
            StringBuilder asyncCommands = new StringBuilder();

            foreach (LuaCsCommand command in commands)
            {
                if (command.IsAsync)
                    asyncCommands.Append(command.CallName)
                        .Append(" = util.async_to_sync(__scriptTable.")
                        .Append(command.CallName)
                        .AppendLine(")");
            }

            return asyncCommands.ToString();
        }
        
        private void SetDefaultTableMembers(LuaEnv luaEnv, LuaTable table)
        {
            table.Set("Vector3", luaEnv.Global.GetInPath<LuaTable>("CS.UnityEngine.Vector3")); //todo: delete
            table.Set("__isScriptRunningRESERVEDVALUE", false);
            table.Set("print", luaEnv.Global.Get<LuaFunction>("print"));
            table.Set("assert", luaEnv.Global.Get<LuaFunction>("assert"));
            table.Set("coroutine", luaEnv.Global.Get<LuaTable>("coroutine"));
            table.Set("self", table);
        }
        private void SetEnumsInTable(LuaEnv luaEnv, LuaTable table, InjectableInLua injectedObject)
        {
            List<Type> enums = new List<Type>();
            MethodInfo[] methods = injectedObject.GetType().GetMethods();

            foreach (MethodInfo m in methods)
            {
                enums.AddRange(m.GetParameters()
                    .Select(x => x.ParameterType)
                    .Where(x => x.IsEnum));
            }
            enums = enums.Distinct().ToList();

            foreach (Type enumType in enums)
            {
                table.Set(enumType.Name, luaEnv.Global.GetInPath<LuaTable>("CS." + enumType.FullName));
            }
        }
    }
}