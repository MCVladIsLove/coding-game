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
    }
}