using System;

namespace ProjectAssets.Resources.Scripts.Structures
{
    [Serializable]
    public struct SCodeStruct
    {
        public int TypingSpeed;
        public int ConversionPrice;
        public long Symbols;
        public int GuaranteedCode;
        public int Experience;
        public int ProgramingLanguage;

        public void SetDefault()
        {
            TypingSpeed = 1;
            ConversionPrice = 1;
            Symbols = 0;
            GuaranteedCode = 250;
            Experience = 0;
            ProgramingLanguage = 0;
        }
    }
}