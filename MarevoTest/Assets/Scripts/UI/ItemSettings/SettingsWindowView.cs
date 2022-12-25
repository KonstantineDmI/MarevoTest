using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemSettings
{
    public class SettingsWindowView : Window
    {
        [SerializeField] private TMP_InputField widthInput;
        [SerializeField] private TMP_InputField letgthInput;
        [SerializeField] private TMP_InputField depthInput;

        [SerializeField] private Button closeButton;
        [SerializeField] private Button applyButton;

        public event Action OnApply;

        public event Action OnClose;
        public event Action<int> OnOpen;

        private void Start()
        {
            closeButton.onClick.AddListener(Close);
            applyButton.onClick.AddListener(Apply);
        }

        public Vector3 GetInputsData()
        {
            if (CheckValidValues())
            {
                var width = Convert.ToInt32(widthInput.text);
                var length = Convert.ToInt32(letgthInput.text);
                var depth = Convert.ToInt32(depthInput.text);
                return new Vector3(width, length, depth);
            }

            return new Vector3();
        }

        public override void Open(params object[] args)
        {
            base.Open(args);
            OnOpen?.Invoke((int)args[0]);
        }

        public override void Close()
        {
            OnClose?.Invoke();
            base.Close();
        }

        private void Apply()
        {
            if (!CheckValidValues())
            {
                return;
            }
            OnApply?.Invoke();
            Close();
        }

        private bool CheckValidValues()
        {
            return !string.IsNullOrWhiteSpace(widthInput.text) && !string.IsNullOrWhiteSpace(letgthInput.text) && !string.IsNullOrWhiteSpace(depthInput.text);
        }
    }
}
