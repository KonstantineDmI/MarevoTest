using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemSettings
{
    public class SettingsWindowController : Window
    {
        [SerializeField] private TMP_InputField widthInput;
        [SerializeField] private TMP_InputField letgthInput;
        [SerializeField] private TMP_InputField depthInput;

        private int _selectedId;

        public override void Open(params object[] args)
        {
            base.Open();
            _selectedId = (int)args[0];
            OnApply += StartARScene;
        }

        public override void Close()
        {
            OnApply -= StartARScene;
            base.Close();
        }

        private void StartARScene()
        {

        }



    }
}
