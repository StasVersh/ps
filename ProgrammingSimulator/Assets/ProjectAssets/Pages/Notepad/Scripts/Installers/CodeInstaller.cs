using ProjectAssets.Pages.Notepad.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CodeInstaller : MonoInstaller
{
    [SerializeField] private GameObject _code;
    [SerializeField] private ScrollRect _scrollRect;
    
    public override void InstallBindings()
    {
        Container.Bind<Code>().FromInstance(new Code(_code, _scrollRect)).AsSingle().NonLazy();
    }   
}