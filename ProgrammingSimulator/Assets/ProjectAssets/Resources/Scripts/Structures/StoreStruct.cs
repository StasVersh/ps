using System;
using UnityEngine.Serialization;

namespace ProjectAssets.Resources.Scripts.Structures
{
    [Serializable]
    public struct StoreStruct
    {
        public int TypingSpeedLevel;
        public int BookOnProgrammingLevel;
        [FormerlySerializedAs("CourseOurSelfPriceLevel")] public int LanguageLevel;
        public int BuildingSpeedLevel;

        public void SetDefault()
        {
            TypingSpeedLevel = 1;
            BookOnProgrammingLevel = 1;
            LanguageLevel = 1;
            BuildingSpeedLevel = 1;
        }
    }
}