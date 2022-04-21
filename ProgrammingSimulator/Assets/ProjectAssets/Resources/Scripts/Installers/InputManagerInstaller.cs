using ProjectAssets.Resources.Scripts.Models;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class InputManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<InputManager>().FromInstance(new InputManager()).AsSingle();
        }
    }
}