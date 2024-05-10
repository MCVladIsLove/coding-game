using System.Text;
using XLua;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System;
using Assets.Scripts.StringConstants;

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
            meta.Set(LuaScriptReservedMemberNames.INJECTED_TABLE, injectedObject);

            string asyncCommands = GetAsyncFunctionsTableCode(injectedObject.Commands.Values.ToList());

            luaEnv.DoString($@"
            util = _G.require 'xlua.util'
            
            function {LuaScriptReservedMemberNames.SUSPEND_COROUTINE_ONE_FRAME}(suspendedCoroutine)
                {LuaScriptReservedMemberNames.INJECTED_TABLE}.AsyncCommandsController:RunLoopIteration(function() 
                    _G.assert(_G.coroutine.resume(suspendedCoroutine)) 
                end)
                _G.coroutine.yield()
            end
            
            reservedMembersTable = {{
                {LuaScriptReservedMemberNames.SUSPEND_COROUTINE_ONE_FRAME} = {LuaScriptReservedMemberNames.SUSPEND_COROUTINE_ONE_FRAME}
            }}

            asyncTable = {{ 
                " + asyncCommands + $@"
            }}
            
            hideMembersTable = {{
                GetType = 1,
                Commands = 1,
                Equals = 1,
                GetHashCode = 1,
                ToString = 1,
                AsyncCommandsController = 1
            }}

            __index = function (table, key)
                if reservedMembersTable[key] ~= nil then
                    return reservedMembersTable[key]
                end

                if hideMembersTable[key] ~= nil then
                    return nil
                end

                if asyncTable[key] ~= nil then
                    return function(...) return asyncTable[key]({LuaScriptReservedMemberNames.INJECTED_TABLE}, ...) end
                end

                if _G.type({LuaScriptReservedMemberNames.INJECTED_TABLE}[key]) == 'function' then 
                    return function (...) return {LuaScriptReservedMemberNames.INJECTED_TABLE}[key]({LuaScriptReservedMemberNames.INJECTED_TABLE}, ...) end
                end
                return {LuaScriptReservedMemberNames.INJECTED_TABLE}[key]
            end", env: meta);
        }

        private string GetAsyncFunctionsTableCode(List<LuaCsCommand> commands)
        {
            StringBuilder asyncCommands = new StringBuilder();

            foreach (LuaCsCommand command in commands)
            {
                if (command.IsAsync)
                    asyncCommands.Append(command.CallName)
                        .Append($" = util.async_to_sync({LuaScriptReservedMemberNames.INJECTED_TABLE}.")
                        .Append(command.CallName)
                        .AppendLine(")");
            }

            return asyncCommands.ToString();
        }
        
        private void SetDefaultTableMembers(LuaEnv luaEnv, LuaTable table)
        {
            table.Set("Vector3", luaEnv.Global.GetInPath<LuaTable>("CS.UnityEngine.Vector3")); //todo: delete
            table.Set(LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING, false);
            table.Set("print", luaEnv.Global.Get<LuaFunction>("print"));
            table.Set("assert", luaEnv.Global.Get<LuaFunction>("assert"));
            table.Set(LuaScriptReservedMemberNames.COROUTINE_TABLE, luaEnv.Global.Get<LuaTable>("coroutine"));
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