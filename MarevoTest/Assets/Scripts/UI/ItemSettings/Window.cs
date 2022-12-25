using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemSettings
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private GameObject windowGameObject;
        [SerializeField] private Button closeButton;
        [SerializeField] private Button applyButton;

        public event Action OnApply;

        public virtual void Open(params object[] args)
        {
            windowGameObject.SetActive(true);
            closeButton.onClick.AddListener(Close);
            applyButton.onClick.AddListener(Apply);
        }

        public virtual void Close()
        {
            windowGameObject.SetActive(false);
        }

        private void Apply()
        {
            OnApply?.Invoke();
        }
    }

}
