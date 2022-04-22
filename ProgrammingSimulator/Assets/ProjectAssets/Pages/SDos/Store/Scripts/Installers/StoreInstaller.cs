using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using ProjectAssets.Pages.SDos.Store.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

public class StoreInstaller : MonoInstaller
{
    [Header("Courses Level")] 
    [SerializeField] private TMP_Text _coursesLevelTitle;
    [SerializeField] private TMP_Text _coursesDescription;
    [SerializeField] private TMP_Text _coursesLevelText;
    [SerializeField] private ButtonManager _coursesSaleButton;
    [SerializeField] private string _coursesLevelPrefix;
    [SerializeField] private List<string> _coursesTitles;
    [SerializeField] private List<string> _coursesDescriptions;
    [SerializeField] private List<int> _coursesCosts;
    
    public override void InstallBindings()
    {
        var store = new Store(
            new Skills(
                new Field(_coursesLevelTitle, _coursesDescription, _coursesLevelText, _coursesSaleButton, _coursesTitles, _coursesDescriptions, _coursesCosts, _coursesLevelPrefix)), 
            new Soft(), 
            new Hardwear());
        Container.Bind<Store>().FromInstance(store).AsSingle().NonLazy();
    }
}