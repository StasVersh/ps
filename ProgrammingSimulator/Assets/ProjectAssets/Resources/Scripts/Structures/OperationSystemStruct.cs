using System;

namespace ProjectAssets.Resources.Scripts.Structures
{
    [Serializable]
    public struct OperationSystemStruct
    {
        public long Scd;
        public int BuildingSpeed;

        public void SetDefault()
        {
            Scd = 0;
            BuildingSpeed = 5;
        }
    }
}