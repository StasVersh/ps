using ProjectAssets.Resources.Scripts.Models;

namespace ProjectAssets.Resources.Scripts.Interfacese
{
    public interface ITask
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public void End(OperationSystem os);
    }
}