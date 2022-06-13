using System;

namespace ProjectAssets.Resources.Scripts.Structures
{
    [Serializable]
    public struct StoreStruct
    {
        public int TypingSpeedLevel;
        public int BookOnProgrammingLevel;
        public int CourseOurSelfPriceLevel;
        public int BuildingSpeedLevel;

        public void SetDefault()
        {
            TypingSpeedLevel = 1;
            BookOnProgrammingLevel = 1;
            CourseOurSelfPriceLevel = 1;
            BuildingSpeedLevel = 1;
        }
    }
}