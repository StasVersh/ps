using System;
using System.IO;
using ProjectAssets.Resources.Scripts.Structures;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Services
{
    public static class OperationSystemDataService
    {
        private static readonly string _dataPath = Application.persistentDataPath + "/OSSave.json";

        public static void SaveData(OperationSystemStruct @struct)
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

        public static OperationSystemStruct LoadData()
        {
            if (!File.Exists(_dataPath))
            {
                var openFile = File.Create(_dataPath);
                openFile.Close();
                var @struct = new OperationSystemStruct();
                @struct.SetDefault();
                SaveData(@struct);
                return @struct;
            }
            
            var json = File.ReadAllText(_dataPath);
            return string.IsNullOrEmpty(json) 
                ? new OperationSystemStruct() : 
                JsonUtility.FromJson<OperationSystemStruct>(json);
        }
    }
}