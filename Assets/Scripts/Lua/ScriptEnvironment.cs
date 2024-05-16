using System;
using XLua;
using Assets.Scripts.StringConstants;
using UnityEngine;

namespace Assets.Scripts.LuaIntegration
{
    public class ScriptEnvironment
    {
        private LuaEnv _luaEnv;
        private LuaAPI _injectedAPI;
        private LuaTable _scriptTable;

        private ILuaTablePreparer _luaTablePreparer;
        private ILuaScriptPreparer _luaScriptPreparer;

        private string _currentScript;
        private string _defaultScript;
        private string _name;

        private Action _compiledScript;

        public bool IsScriptRunning => _scriptTable.Get<bool>(LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING);
        public string Name => _name;
        public string CurrentScript => _currentScript;

        public event Action ScriptCompiled;
        public event Action<LuaException> RuntimeExceptionThrown;

        public ScriptEnvironment(LuaEnv luaEnv,
            LuaAPI injectedAPI,
            string defaultScript,
            string name,
            ILuaTablePreparer tablePreparer,
            ILuaScriptPreparer scriptPreparer)
        {
            _luaEnv = luaEnv;
            _injectedAPI = injectedAPI;
            _luaTablePreparer = tablePreparer;
            _luaScriptPreparer = scriptPreparer;
            _currentScript = defaultScript;
            _defaultScript = defaultScript;
            _name = name;

            _injectedAPI.AsyncCommandsController.AsyncExecutionFailed += OnRuntimeException;
            CreateTable();
        }

        private void CreateTable()
        {
            _scriptTable = _luaEnv.NewTable();
            _luaTablePreparer.PrepareTable(_luaEnv, _scriptTable, _injectedAPI);
        }

        public void SetScript(string newScript)
        {
            _currentScript = newScript;
        }

        public LuaException TryExecuteScript()
        {
            try
            {
                if (_compiledScript == null)
                    throw new LuaException($"Script ['{_name}'] has compilation errors!");

                _compiledScript();
            }
            catch (LuaException e)
            {
                OnRuntimeException(e);
                return e;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return null;
        }

        public LuaException TryCompileScript()
        {
            string preparedScript = _luaScriptPreparer.PrepareScript(_currentScript, _injectedAPI);
            try
            {
                _luaEnv.DoString(preparedScript, chunkName: _name, env: _scriptTable);
                _compiledScript = _scriptTable.Get<Action>(LuaScriptReservedMemberNames.SCRIPT_AS_FUNCTION);
            }
            catch (LuaException e)
            {
                _compiledScript = null;
                return e;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            
            ScriptCompiled?.Invoke();
            return null;
        }

        public void ReloadTable()
        {
            if (IsScriptRunning)
                _injectedAPI.AsyncCommandsController.StopAsyncExecution();
            _scriptTable.Dispose();
            CreateTable();
        }

        public void Reset()
        {
            SetScript(_defaultScript);
            ReloadTable();
            TryCompileScript();
        }

        private void OnRuntimeException(LuaException exception)
        {
            _luaEnv.DoString($"{LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING} = false", chunkName: _name, env: _scriptTable);
            RuntimeExceptionThrown?.Invoke(exception);
        }
    }
}