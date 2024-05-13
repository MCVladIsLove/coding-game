using System;
using XLua;
using Assets.Scripts.StringConstants;
using UnityEngine;

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
        private string _name;

        private Action _compiledScript;

        public bool IsScriptRunning => _scriptTable.Get<bool>(LuaScriptReservedMemberNames.IS_SCRIPT_RUNNING);
        public string Name => _name;

        public event Action ScriptCompiled;
        public event Action<LuaException> RuntimeExceptionThrown;

        public ScriptEnvironment(LuaEnv luaEnv,
            InjectableInLua injectedObject,
            string defaultScript,
            string name,
            ILuaTablePreparer tablePreparer,
            ILuaScriptPreparer scriptPreparer)
        {
            _luaEnv = luaEnv;
            _injectedObject = injectedObject;
            _luaTablePreparer = tablePreparer;
            _luaScriptPreparer = scriptPreparer;
            _currentScript = defaultScript;
            _defaultScript = defaultScript;
            _name = name;

            _injectedObject.AsyncCommandsController.AsyncExecutionFailed += OnRuntimeException;
            CreateTable();
        }

        private void CreateTable()
        {
            _scriptTable = _luaEnv.NewTable();
            _luaTablePreparer.PrepareTable(_luaEnv, _scriptTable, _injectedObject);
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
            string preparedScript = _luaScriptPreparer.PrepareScript(_currentScript, _injectedObject);
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
                _injectedObject.AsyncCommandsController.StopAsyncExecution();
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
            RuntimeExceptionThrown?.Invoke(exception);
        }
    }
}