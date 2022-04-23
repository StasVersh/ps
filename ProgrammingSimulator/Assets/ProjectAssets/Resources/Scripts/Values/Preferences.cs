using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Values
{
    public static class Preferences
    {
        public const string Coins = "SCD";
        public const string CoursesLevel = "CoursesLevel";

        public static void ResetAll()
        {
            PlayerPrefs.SetInt(Coins, 0);
            PlayerPrefs.SetInt(CoursesLevel, 0);
        }
    }
}