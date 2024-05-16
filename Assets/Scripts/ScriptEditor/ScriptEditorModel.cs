using System.Collections;
using System.Collections.Generic;
using Zenject;
using Assets.Scripts.LuaIntegration;

namespace Assets.Scripts.ScriptEditor
{
    public class ScriptEditorModel
    {
        private ScriptEnvironment[] _overridableFunctions;

        public ScriptEnvironment[] OverridableFunctions => _overridableFunctions;

        public ScriptEditorModel(ScriptEnvironment[] overridableFunctions)
        {
            _overridableFunctions = overridableFunctions;
        }
    }
}