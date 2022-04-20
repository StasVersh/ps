using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EnvironmentalInstaller : MonoInstaller
{
    [Header("Desktop")] 
    [SerializeField] private Image _wallpaper;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _notePadButton;
    [Header("Notepad")] 
    [SerializeField] private GameObject _notePad;
    
    public override void InstallBindings()
    {
        Container.Bind<OS>().FromInstance(new OS(new Desctop(_wallpaper, new Taskbar(_startButton, _notePadButton)), new Notepad(_notePad)))
            .AsSingle();
    }
}