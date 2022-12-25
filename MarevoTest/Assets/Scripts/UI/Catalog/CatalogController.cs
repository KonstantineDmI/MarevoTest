using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UI.ItemSettings;
using UnityEngine;

namespace UI.Catalog
{
    public class CatalogController : Window
    {
        [SerializeField] private Transform catalogItemsParent;
        [SerializeField] private CatalogItem catalogItemPrefab;
        [SerializeField] private SettingsWindowView settingsWindowView;
        [SerializeField] private SpreadSheet spreadSheet;

        private void Start()
        {
            spreadSheet.OnDataInitialized += Initialize;
            settingsWindowView.OnApply += Close;
        }

        private void OnDestroy()
        {
            spreadSheet.OnDataInitialized -= Initialize;
            settingsWindowView.OnApply -= Close;
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
                item.SetIcon(spreadSheet.GetPreviewById(item.GetId()));
            }
        }

        private void OpenSettingsWindow(int id)
        {
            settingsWindowView.Open(id);
        }
    }
}
