using System;
using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

public class TabBarController : MonoBehaviour
{
    [SerializeField] private List<Button> _tabs;
    [SerializeField] private List<GameObject> _pages;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _normalColor;

    private List<TabModel> _tabModels;

    private void Start()
    {
        var tab = new TabModel(_tabs[0], 0, _pages[0]);
        _tabModels.Add(tab);

        /*foreach (TabModel tabModel in _tabModels)
        {
            tabModel.OnClick.AddListener(delegate { OnTabClick(tabModel); });
        }*/
    }

    private void OnTabClick(TabModel tabModel)
    {
        Debug.Log(tabModel);
        var buttonColors = tabModel.Button.colors;
        buttonColors.normalColor = _selectedColor;
        buttonColors.selectedColor = _selectedColor;
    }
}
