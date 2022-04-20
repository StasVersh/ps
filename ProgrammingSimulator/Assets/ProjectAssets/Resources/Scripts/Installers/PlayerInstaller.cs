using ProjectAssets.Resources.Scripts.Models;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Player>().FromInstance(new Player()).AsSingle().NonLazy();
    }
}