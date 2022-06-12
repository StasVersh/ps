using ProjectAssets.Resources.Scripts.Models;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class OperationSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<OperationSystem>().FromInstance(new OperationSystem()).AsSingle();
        }
    }
}