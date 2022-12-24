using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemSettings
{
    public class SettingsWindowView : MonoBehaviour
    {
        [SerializeField] private GameObject windowGameObject;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button applyButton;

        public event Action OnApply;

        public void Open()
        {
            windowGameObject.SetActive(true);
        }

        public void Close()
        {
            windowGameObject.SetActive(false);
        }

        private void Apply()
        {
            OnApply?.Invoke();
        }
    }

}