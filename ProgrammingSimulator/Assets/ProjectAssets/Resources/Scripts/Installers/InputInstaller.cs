using Zenject;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<Input>().FromInstance(new Input()).AsSingle();
        }
    }
}