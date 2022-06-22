using ProjectAssets.Resources.Scripts.Models;

namespace ProjectAssets.Resources.Scripts.Interfacese
{
    public interface ITile
    {
        public long GetCoast();
        public bool Buy(OperationSystem operationSystem);
    }
}