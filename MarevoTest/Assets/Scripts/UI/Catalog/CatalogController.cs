using System.Collections;
using System.Collections.Generic;
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
            foreach (var row in data.Rows)
            {
                foreach(var column in data.Columns)
                {
                    var item = Instantiate(catalogItemPrefab, catalogItemsParent);
                    item.SetLabelText(row.ToString());
                }
            }
        }
    }
}