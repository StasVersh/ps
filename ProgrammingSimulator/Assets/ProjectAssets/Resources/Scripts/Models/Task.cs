using Zenject;

namespace ProjectAssets.Resources.Scripts.Models
{
    public abstract class Task
    {
        public string Name { get; }
        public int Speed { get; }

        public abstract void End(PlayerStats _playerStats);
    }
}