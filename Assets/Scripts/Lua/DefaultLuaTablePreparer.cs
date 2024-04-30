using System.Text;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    public class DefaultLuaTablePreparer : ILuaTablePreparer
    {
        public void PrepareTable(LuaEnv luaEnv, LuaTable table, InjectedInLua injectedObject)
        {
            LuaTable meta = luaEnv.NewTable();
            meta.Set("_G", luaEnv.Global);

            meta.Set("__scriptTable", injectedObject);

            StringBuilder asyncCommands = new StringBuilder();

            foreach (LuaCsCommand command in injectedObject.Commands.Values)
            {
                if (command.IsAsync)
                    asyncCommands.Append(command.CallName)
                        .Append(" = util.async_to_sync(__scriptTable.")
                        .Append(command.CallName)
                        .AppendLine(")");
            }

            luaEnv.DoString(@"
            util = _G.require 'xlua.util'

            asyncTable = { 
                " + asyncCommands.ToString() + @"
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

            table.SetMetaTable(meta);
            meta.Dispose();
            table.Set("Vector3", luaEnv.Global.GetInPath<LuaTable>("CS.UnityEngine.Vector3")); //todo: delete
            table.Set("print", luaEnv.Global.Get<LuaFunction>("print"));
            table.Set("assert", luaEnv.Global.Get<LuaFunction>("assert"));
            table.Set("coroutine", luaEnv.Global.Get<LuaTable>("coroutine"));
            table.Set("self", table);
        }
    }
}