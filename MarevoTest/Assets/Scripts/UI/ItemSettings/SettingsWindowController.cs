using Objects;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ItemSettings
{
    public class SettingsWindowController : MonoBehaviour
    {

        [SerializeField] private SettingsWindowView settingsWindowView;
        [SerializeField] private ObjectsController objectController;

        private int _selectedId;

        private void Awake()
        {
            settingsWindowView.OnOpen += InitializeWindow;
        }

        private void InitializeWindow(int id)
        {
            Debug.Log("INITIALIZED");
            _selectedId = id;
            settingsWindowView.OnApply += StartARScene;
        }

        private void StartARScene()
        {
            var scale = settingsWindowView.GetInputsData();

            if(scale == Vector3.zero)
            {
                return;
            }

            objectController.SetTexture(_selectedId);
            objectController.SetScale(scale);
        }



    }
}
