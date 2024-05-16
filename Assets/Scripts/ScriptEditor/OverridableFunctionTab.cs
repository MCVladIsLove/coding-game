using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Events;
using Assets.Scripts.LuaIntegration;

namespace Assets.Scripts.ScriptEditor
{
    public class OverridableFunctionTab : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _name;

        public int TabIndex { get; private set; }

        public void Construct(int tabIndex, string functionName, Action<int> onSelected)
        {
            TabIndex = tabIndex;
            _name.text = functionName;
            _button.onClick.AddListener(() => onSelected(TabIndex));
        }
    }
}