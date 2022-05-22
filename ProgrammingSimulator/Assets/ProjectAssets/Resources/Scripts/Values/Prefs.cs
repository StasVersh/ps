using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Values
{
    public static class Prefs
    {
        #region Const

            private const string Scd = "SCD";
            private const string TypingSpeed = "TypingSpeed";
        
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

        #endregion
    }
}