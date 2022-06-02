using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Utilities
{
    public static class Prefs
    {
        #region Const

            private const string Scd = "SCD";
            private const string TypingSpeed = "TypingSpeed";
            private const string ConversionPrice = "ConversionPrice";
            private const string Symbols = "Symbols";
            private const string Experience = "Experience";
            private const string ProgramingLanguage = "ProgramingLanguage";
        
        #endregion

        #region Getters

        public static int GetScd()
        {
            return PlayerPrefs.GetInt(Scd);
        }
        
        public static int GetTypingSpeed()
        {
            return PlayerPrefs.GetInt(TypingSpeed) > 0 ? PlayerPrefs.GetInt(TypingSpeed) : 1;
        }
        
        public static int GetConversionPrice()
        {
            return PlayerPrefs.GetInt(ConversionPrice) > 0 ? PlayerPrefs.GetInt(ConversionPrice) : 1;
        }
        
        public static int GetSymbols()
        {
            return PlayerPrefs.GetInt(Symbols);
        }
        
        public static int GetExperience()
        {
            return PlayerPrefs.GetInt(Experience) >= 0 ? PlayerPrefs.GetInt(Experience) : 0;
        }
        
        public static int GetProgramingLanguage()
        {
            return PlayerPrefs.GetInt(ProgramingLanguage) >= 0 ? PlayerPrefs.GetInt(ProgramingLanguage) : 0;
        }

        #endregion

        #region Setters

        public static void SetScd(int value)
        {
            PlayerPrefs.SetInt(Scd, value);
        }
        
        public static void SetTypingSpeed(int value)
        {
            PlayerPrefs.SetInt(TypingSpeed, value);
        }
        
        public static void SetConversionPrice(int value)
        {
            PlayerPrefs.SetInt(ConversionPrice, value);
        }
        
        public static void SetSymbols(int value)
        {
            PlayerPrefs.SetInt(Symbols, value);
        }
        
        public static void SetExperience(int value)
        {
            PlayerPrefs.SetInt(Experience, value);
        }
        
        public static void SetProgramingLanguage(int value)
        {
            PlayerPrefs.SetInt(ProgramingLanguage, value);
        }

        #endregion
    
        #region Resets

        public static void ResetAllPrefs()
        {
            SetScd(0);
            SetTypingSpeed(1);
            SetConversionPrice(1);
            SetSymbols(0);
            SetExperience(0);
            SetProgramingLanguage(0);
        }

        #endregion
    }
}