using System;

namespace ProjectAssets.Resources.Scripts.Structures
{
    [Serializable]
    public struct SCodeStruct
    {
        public int TypingSpeed;
        public int ConversionPrice;
        public int Symbols;
        public int Experience;
        public int ProgramingLanguage;

        public void SetDefault()
        {
            TypingSpeed = 1;
            ConversionPrice = 1;
            Symbols = 0;
            Experience = 0;
            ProgramingLanguage = 0;
        }
    }
}