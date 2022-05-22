using ProjectAssets.Resources.Scripts.Models;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class PlayerStatsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerStats>().FromInstance(new PlayerStats()).AsSingle();
        }
    }
}