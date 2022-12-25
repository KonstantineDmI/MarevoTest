using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private GameObject catalogGameObject;

        private void Start()
        {
            button.onClick.AddListener(BackToCatalog);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(BackToCatalog);
        }

        private void BackToCatalog()
        {
            catalogGameObject.SetActive(true);
        }
    }
}
