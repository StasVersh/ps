using System;
using System.IO;
using ProjectAssets.Resources.Scripts.Structures;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Services
{
    public static class StoreDataService
    {
        private static readonly string _dataPath = Application.persistentDataPath + "/StoreSave.json";

        public static void SaveData(StoreStruct @struct)
        {
            var json = JsonUtility.ToJson(@struct);
            try
            {
                File.WriteAllText(_dataPath, json);
            }
            catch (Exception e)
            {    
                Debug.Log(e);
            }
        }

        public static StoreStruct LoadData()
        {
            if (!File.Exists(_dataPath))
            {
                var openFile = File.Create(_dataPath);
                openFile.Close();
                var @struct = new StoreStruct();
                @struct.SetDefault();
                SaveData(@struct);
                return @struct;
            }
            
            var json = File.ReadAllText(_dataPath);
            return string.IsNullOrEmpty(json) 
                ? new StoreStruct() : 
                JsonUtility.FromJson<StoreStruct>(json);
        }
    }
}