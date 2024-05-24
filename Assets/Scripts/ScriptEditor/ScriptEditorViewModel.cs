using Assets.Scripts.LuaIntegration;
using XLua;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using Assets.Scripts.SyntaxHighlighting;
using Assets.Scripts.LuaLexing;

namespace Assets.Scripts.ScriptEditor
{
    public class ScriptEditorViewModel
    {
        private ScriptEditorModel _model;
        private SyntaxHighlighter _syntaxHighlighter;
        private LuaLexer _luaLexer;

        private string _displayedText;
        private int _currentFunctionIndex;

        private string[] _rememberedScripts;

        private ScriptEnvironment CurrentFunction => _model.OverridableFunctions[_currentFunctionIndex];

        public int CurrentFunctionIndex => _currentFunctionIndex;

        public event Action<LuaException> CompilationFailed;
        public event Action<string> CurrentScriptSwitched;
        public event Action<ScriptEnvironment[]> FunctionSetChanged;
        public event Action<string> DisplayedTextChanged;

        public ScriptEditorViewModel(ScriptEditorModel model, SyntaxHighlighter syntaxHighlighter, LuaLexer lexer)
        {
            _luaLexer = lexer;
            _syntaxHighlighter = syntaxHighlighter;
            _model = model;
            _currentFunctionIndex = 0;
            _rememberedScripts = new string[_model.OverridableFunctions.Length];
            for (int i = 0; i < _model.OverridableFunctions.Length; i++)
                _rememberedScripts[i] = _model.OverridableFunctions[i].CurrentScript;
        }

        public void ChangeScriptText(string newScriptText)
        {
            List<Token> tokens = _luaLexer.Tokenize(newScriptText);
            _displayedText = _syntaxHighlighter.GetHighlightedText(tokens);
            DisplayedTextChanged?.Invoke(_displayedText);

            _rememberedScripts[_currentFunctionIndex] = newScriptText;
        }

        public void Compile(string script)
        {
            CurrentFunction.SetScript(script);
            CurrentFunction.ReloadTable();

            LuaException exception = CurrentFunction.TryCompileScript();
            if (exception != null)
            {
                CompilationFailed?.Invoke(exception);
            }
        }

        public void ResetFunctionToDefault()
        {
            CurrentFunction.Reset();
            _rememberedScripts[_currentFunctionIndex] = CurrentFunction.CurrentScript;
            CurrentScriptSwitched?.Invoke(CurrentFunction.CurrentScript);
        }

        public void SwitchCurrentFunction(int functionIndex)
        {
            _currentFunctionIndex = functionIndex;
            CurrentScriptSwitched?.Invoke(_rememberedScripts[_currentFunctionIndex]);
        }

        public void TriggerViewRefresh()
        {
            FunctionSetChanged?.Invoke(_model.OverridableFunctions);
            CurrentScriptSwitched?.Invoke(_rememberedScripts[_currentFunctionIndex]);
        }
    }
}