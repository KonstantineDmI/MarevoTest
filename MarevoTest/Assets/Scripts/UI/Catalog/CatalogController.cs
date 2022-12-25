using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UI.ItemSettings;
using UnityEngine;

namespace UI.Catalog
{
    public class CatalogController : MonoBehaviour
    {
        [SerializeField] private Transform catalogItemsParent;
        [SerializeField] private CatalogItem catalogItemPrefab;
        [SerializeField] private SettingsWindowController settingsWindowController;
        [SerializeField] private SpreadSheet spreadSheet;

        private void Start()
        {
            spreadSheet.OnDataInitialized += Initialize;
        }

        private void OnDestroy()
        {
            spreadSheet.OnDataInitialized -= Initialize;
        }

        private void Initialize()
        {
            var data = spreadSheet.GetDataTable();
            foreach (DataRow row in data.Rows)
            {
                var item = Instantiate(catalogItemPrefab, catalogItemsParent);
                item.InitializeItem(Convert.ToInt32(row["Id"]));
                item.OnSelectButtonClicked += OpenSettingsWindow;
                item.SetLabelText(row["Title"].ToString());
                item.SetIcon(spreadSheet.GetTextureById(item.GetId()));
            }
        }

        private void OpenSettingsWindow(int id)
        {
            settingsWindowController.Open(id);
        }
    }
}
