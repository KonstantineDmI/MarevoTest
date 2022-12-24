using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Catalog
{
    public class CatalogItem : MonoBehaviour
    { 
        [SerializeField] private Button itemButton;
        [SerializeField] private TextMeshProUGUI itemLabel;
        [SerializeField] private Image itemImage;

        public Action<int> OnSelectButtonClicked;

        public int _id;

        private void OnDestroy()
        {
            itemButton.onClick.RemoveListener(SelectItem);
        }

        public void InitializeItem(int id)
        {
            _id = id;

            itemButton.onClick.AddListener(SelectItem);
        }

        public void SetLabelText(string text)
        {
            itemLabel.text = text;
        }

        public void SetIcon(Sprite sprite)
        {
            itemImage.sprite = sprite;
        }

        private void SelectItem()
        {
            OnSelectButtonClicked?.Invoke(_id);
        }
    }
}
