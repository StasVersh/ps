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
            private const string BuildingSpeed = "BuildingSpeed";
            private const string TypingSpeedLevel = "TypingSpeedLevel";
            private const string BookOnProgrammingLevel = "BookOnProgrammingLevel";
            private const string CourseOurSelfPriceLevel = "CourseOurSelfPriceLevel";
            private const string BuildingSpeedLevel = "BuildingSpeedLevel";

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
        
        public static int GetBuildingSpeed()
        {
            return PlayerPrefs.GetInt(BuildingSpeed) >= 5 ? PlayerPrefs.GetInt(BuildingSpeed) : 5;
        }
        
        public static int GetTypingSpeedLevel()
        {
            return PlayerPrefs.GetInt(TypingSpeedLevel) > 0 ? PlayerPrefs.GetInt(TypingSpeedLevel) : 1;
        }
        
        public static int GetBookOnProgrammingLevel()
        {
            return PlayerPrefs.GetInt(BookOnProgrammingLevel) > 0 ? PlayerPrefs.GetInt(BookOnProgrammingLevel) : 1;
        }
        
        public static int GetCourseOurSelfPriceLevel()
        {
            return PlayerPrefs.GetInt(CourseOurSelfPriceLevel) > 0 ? PlayerPrefs.GetInt(CourseOurSelfPriceLevel) : 1;
        }
        
        public static int GetBuildingSpeedLevel()
        {
            return PlayerPrefs.GetInt(BuildingSpeedLevel) > 0 ? PlayerPrefs.GetInt(BuildingSpeedLevel) : 1;
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
        
        public static void SetBuildingSpeed(int value)
        {
            PlayerPrefs.SetInt(BuildingSpeed, value);
        }
        
        public static void SetTypingSpeedLevel(int value)
        {
            PlayerPrefs.SetInt(TypingSpeedLevel, value);
        }
        
        public static void SetBookOnProgrammingLevel(int value)
        {
            PlayerPrefs.SetInt(BookOnProgrammingLevel, value);
        }
        
        public static void SetCourseOurSelfPriceLevel(int value)
        {
            PlayerPrefs.SetInt(CourseOurSelfPriceLevel, value);
        }
        
        public static void SetBuildingSpeedLevel(int value)
        {
            PlayerPrefs.SetInt(BuildingSpeedLevel, value);
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
            SetBuildingSpeed(5);
            SetTypingSpeedLevel(1);
            SetBookOnProgrammingLevel(1);
            SetCourseOurSelfPriceLevel(1);
            SetTypingSpeedLevel(1);
            SetBuildingSpeedLevel(1);
        }

        #endregion
    }
}