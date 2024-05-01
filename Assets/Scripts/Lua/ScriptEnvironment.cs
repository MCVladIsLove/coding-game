using System;
using XLua;

namespace Assets.Scripts.LuaIntegration
{
    public class ScriptEnvironment
    {
        private LuaEnv _luaEnv;
        private InjectableInLua _injectedObject;
        private LuaTable _scriptTable;

        private ILuaTablePreparer _luaTablePreparer;
        private ILuaScriptPreparer _luaScriptPreparer; 

        private string _currentScript;
        private string _defaultScript;

        public ScriptEnvironment(LuaEnv luaEnv, 
            InjectableInLua injectedObject, 
            string defaultScript, 
            ILuaTablePreparer tablePreparer, 
            ILuaScriptPreparer scriptPreparer)
        {
            _luaEnv = luaEnv;
            _injectedObject = injectedObject;
            _luaTablePreparer = tablePreparer;
            _luaScriptPreparer = scriptPreparer;
            _currentScript = defaultScript;
            _defaultScript = defaultScript;
            CreateTable();
        }

        private void CreateTable()
        {
            _scriptTable = _luaEnv.NewTable();
            _luaTablePreparer.PrepareTable(_luaEnv, _scriptTable, _injectedObject);
        }

        public T GetScriptAs<T>()
        {
            string preparedScript = _luaScriptPreparer.PrepareScript(_currentScript, _injectedObject);
            _luaEnv.DoString(preparedScript, env: _scriptTable);
            
            return _scriptTable.Get<T>("__scriptAsFunction");
        }

        public bool IsScriptRunning()
        {
            return _scriptTable.Get<bool>("__isScriptRunningRESERVEDVALUE");
        }
    }
}