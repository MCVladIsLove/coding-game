using UnityEngine;
using UnityEngine.UI;
using TMPro;
using XLua;
using System;
using Assets.Scripts.LuaIntegration;

namespace Assets.Scripts.ScriptEditor
{
    public class ScriptEditorView : MonoBehaviour
    {
        [SerializeField] private Button _resetButton;
        [SerializeField] private Button _compileButton;
        [SerializeField] private LayoutGroup _functionsGroup;
        [SerializeField] private TMP_InputField _codeInputField;
        [SerializeField] private TMP_Text _codeDisplayText;
        [SerializeField] private Button _closeButton;
        [SerializeField] private TMP_Text _hintText;
        [SerializeField] private OverridableFunctionTab _functionTabPrefab;

        private ScriptEditorViewModel _viewModel;
        private OverridableFunctionTab[] _functionsTabs;

        private void OnEnable()
        {
            _viewModel.CompilationFailed += OnCompilationFailed;
            _viewModel.CurrentScriptSwitched += OnCurrentScriptSwitched;
            _viewModel.FunctionSetChanged += OnFunctionSetChanged;
            _viewModel.DisplayedTextChanged += OnDisplayedTextChanged;

            _resetButton.onClick.AddListener(OnResetPressed);
            _closeButton.onClick.AddListener(OnClosePressed);
            _compileButton.onClick.AddListener(OnCompilePressed);
            _codeInputField.onValueChanged.AddListener(OnTextInputChanged);
        }

        private void OnDisable()
        {
            _viewModel.CompilationFailed -= OnCompilationFailed;
            _viewModel.CurrentScriptSwitched -= OnCurrentScriptSwitched;
            _viewModel.FunctionSetChanged -= OnFunctionSetChanged;
            _viewModel.DisplayedTextChanged -= OnDisplayedTextChanged;

            _resetButton.onClick.RemoveListener(OnResetPressed);
            _closeButton.onClick.RemoveListener(OnClosePressed);
            _compileButton.onClick.RemoveListener(OnCompilePressed);
            _codeInputField.onValueChanged.RemoveListener(OnTextInputChanged);
        }

        private void OnDisplayedTextChanged(string text)
        {
            _codeDisplayText.text = text;
        }

        private void OnFunctionSetChanged(ScriptEnvironment[] functionSet)
        {
            RemoveFunctionsTabs();
            CreateFunctonsTabs(functionSet);
        }

        private void OnCurrentScriptSwitched(string script)
        {
            _codeInputField.text = script;
        }

        private void OnCompilationFailed(LuaException exception)
        {
            // not implemented
            Debug.LogError(exception);
        }

        private void OnTextInputChanged(string script)
        {
            _viewModel.ChangeScriptText(script);
        }

        private void OnCompilePressed()
        {
            _viewModel.Compile(_codeInputField.text);
        }

        private void OnClosePressed()
        {
            gameObject.SetActive(false);
        }

        private void OnResetPressed()
        {
            _viewModel.ResetFunctionToDefault();
        }

        public void SetViewModel(ScriptEditorViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Open()
        {
            gameObject.SetActive(true);

            _viewModel.TriggerViewRefresh();
        }

        private void RemoveFunctionsTabs()
        {
            for (int i = 0; i < _functionsGroup.transform.childCount; i++)
            {
                Destroy(_functionsGroup.transform.GetChild(i).gameObject);
            }
        }

        private void CreateFunctonsTabs(ScriptEnvironment[] functions)
        {
            _functionsTabs = new OverridableFunctionTab[functions.Length];
            for (int i = 0; i < functions.Length; i++)
            {
                _functionsTabs[i] = Instantiate(_functionTabPrefab, _functionsGroup.transform);
                _functionsTabs[i].Construct(i, functions[i].Name, OnFunctionTabPressed);
            }
        }

        private void OnFunctionTabPressed(int tabIndex)
        {
            _viewModel.SwitchCurrentFunction(tabIndex);
        }
    }
}