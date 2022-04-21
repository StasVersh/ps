using ProjectAssets.Pages.SDos.SDCode.Scripts.Models;
using Zenject;

namespace ProjectAssets.Pages.SDos.SDCode.Scripts.Installers
{
    public class SDCodeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SDCodeModel>().FromInstance(new SDCodeModel()).AsSingle();
        }
    }
}