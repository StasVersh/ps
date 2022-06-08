using ProjectAssets.Resources.Scripts.Models;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class StoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Store>().FromInstance(new Store()).AsSingle();
        }
    }
}