using System;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    public class ScriptEnvironment
    {
        private LuaEnv _luaEnv;
        private InjectedInLua _injectedObject;
        private LuaTable _scriptTable;

        private ILuaTablePreparer _luaTablePreparer;
        private ILuaScriptPreparer _luaScriptPreparer;

        private string _script;

        public ScriptEnvironment(LuaEnv luaEnv, InjectedInLua injectedObject, string defaultScript, ILuaTablePreparer tablePreparer, ILuaScriptPreparer scriptPreparer)
        {
            _luaEnv = luaEnv;
            _injectedObject = injectedObject;
            _luaTablePreparer = tablePreparer;
            _luaScriptPreparer = scriptPreparer;
            _script = defaultScript;
            CreateTable();
            //if (_script != null)
              //  GetScriptAsCsFuncton()(); // todo: refactor
        }

        private void CreateTable()
        {
            _scriptTable = _luaEnv.NewTable();
            _luaTablePreparer.PrepareTable(_luaEnv, _scriptTable, _injectedObject);
        }

        public Action GetScriptAsCsFuncton() // todo: refactor
        {
            _script = _luaScriptPreparer.PrepareScript(_script);
            _luaEnv.DoString(_script, env: _scriptTable);
            _scriptTable.Get("__scriptAsFunction", out Action resultFunc);
            return resultFunc;
        }
    }
}