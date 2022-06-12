using System.IO;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Utilities
{
    public static class PlayerStatsDataService
    {
        private static readonly string _dataPath = Application.persistentDataPath + "/PlayerStatsSave.json";

        public static void SaveData(SCode sCode)
        {
            var json = JsonUtility.ToJson(sCode);
            File.WriteAllText(json, _dataPath);
        }

        public static SCode LoadData()
        {
            var json = "";
            using var rider = new StreamReader(_dataPath);
            while (rider.ReadLine() != null)
            {
                json += rider.ReadLine();
            }

            return string.IsNullOrEmpty(json) 
                ? new SCode(null) 
                : JsonUtility.FromJson<SCode>(json);
        }
    }
}