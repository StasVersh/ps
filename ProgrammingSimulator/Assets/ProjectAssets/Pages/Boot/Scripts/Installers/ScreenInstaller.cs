using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class ScreenInstaller : MonoInstaller
{
    [FormerlySerializedAs("_sDoc")] [SerializeField] private Button _sDos;
    [SerializeField] private Button _savaDoors;
    public override void InstallBindings()
    {
        Container.Bind<BootUI>().FromInstance(new BootUI(_sDos, _savaDoors)).AsSingle();
    }
}