using System;
using XLua;
using Assets.Scripts.StringConstants;

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

        public bool IsScriptRunning => _scriptTable.Get<bool>(LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING);

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

        public Action GetScriptAsDelegate()
        {
            string preparedScript = _luaScriptPreparer.PrepareScript(_currentScript, _injectedObject);
            _luaEnv.DoString(preparedScript, env: _scriptTable);

            return _scriptTable.Get<Action>(LuaScriptReservedMemberNames.SCRIPT_AS_FUNCTION);
        }

        public void SetScript(string newScript)
        {
            _currentScript = newScript;
        }

        public void ReloadTable()
        {
            if (IsScriptRunning)
                _injectedObject.AsyncCommandsController.StopAsyncExecution();
            _scriptTable.Dispose();
            CreateTable();
        }

        public void Reset()
        {
            SetScript(_defaultScript);
            ReloadTable();
        }
    }
}