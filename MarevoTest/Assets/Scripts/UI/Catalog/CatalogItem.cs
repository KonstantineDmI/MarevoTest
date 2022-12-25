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

        private int _id;

        private void OnDestroy()
        {
            itemButton.onClick.RemoveListener(SelectItem);
        }

        public void InitializeItem(int id)
        {
            _id = id;

            itemButton.onClick.AddListener(SelectItem);
        }

        public int GetId()
        {
            return _id;
        }

        public void SetLabelText(string text)
        {
            itemLabel.text = text;
        }

        public void SetIcon(Texture2D texture)
        {
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2());
            itemImage.sprite = sprite;
        }

        private void SelectItem()
        {
            Debug.Log("clicked");
            OnSelectButtonClicked?.Invoke(_id);
        }
    }
}
