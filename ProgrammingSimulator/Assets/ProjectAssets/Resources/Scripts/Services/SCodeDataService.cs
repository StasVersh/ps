using System;
using System.IO;
using ProjectAssets.Resources.Scripts.Structures;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Services
{
    public static class SCodeDataService
    {
        private static readonly string _dataPath = Application.persistentDataPath + "/SCodeSave.json";

        public static void SaveData(SCodeStruct @struct)
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

        public static SCodeStruct LoadData()
        {
            if (!File.Exists(_dataPath))
            {
                var openFile = File.Create(_dataPath);
                openFile.Close();
                var @struct = new SCodeStruct();
                @struct.SetDefault();
                SaveData(@struct);
                return @struct;
            }
            
            var json = File.ReadAllText(_dataPath);
            return string.IsNullOrEmpty(json) 
                ? new SCodeStruct() : 
                JsonUtility.FromJson<SCodeStruct>(json);
        }
    }
}