using Data;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.ItemSettings;
using UnityEngine;

public class LoadingScreen : Window
{
    [SerializeField] private string textTemplate;
    [SerializeField] private TextMeshProUGUI loadingLabel;
    [SerializeField] private SpreadSheet data;

    private void Start()
    {
        data.OnItemInitialized += UpdateView;
        data.OnDataInitialized += Close;
    }

    private void UpdateView(int currentValue, int totalValue)
    {
        loadingLabel.text = string.Format(textTemplate, currentValue, totalValue);
    }

}
