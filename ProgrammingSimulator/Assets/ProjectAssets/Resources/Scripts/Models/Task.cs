using Zenject;

namespace ProjectAssets.Resources.Scripts.Models
{
    public abstract class Task
    {
        public string Name { get; protected set; }
        public int Speed { get; protected set; } 

        public abstract void End(PlayerStats _playerStats);
    }
}