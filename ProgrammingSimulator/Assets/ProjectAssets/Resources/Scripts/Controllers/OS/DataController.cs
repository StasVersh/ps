using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Services;
using ProjectAssets.Resources.Scripts.Structures;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers.OS
{
    public class DataController : MonoBehaviour
    {
        private SCode _sCode;
        private Store _store;
        private Input _input;
        private OperationSystem _os;

        [Inject]
        private void Construct(SCode sCode, Store store, OperationSystem os, Input input)
        {
            _sCode = sCode;
            _store = store;
            _os = os;
            _input = input;
        }

        private void Start()
        {
            _input.ResetAll.AddListener(ResetAll);
            
            _sCode.StructToModel(SCodeDataService.LoadData());
            EventHandler.SCode.AddListener(SaveSCode);

            _store.StructToModel(StoreDataService.LoadData());
            EventHandler.Store.AddListener(SaveStore);
            
            _os.StructToModel(OperationSystemDataService.LoadData());
            EventHandler.OperationSystem.AddListener(SaveOperationSystem);
        }

        private void SaveOperationSystem()
        {
            OperationSystemDataService.SaveData(_os.ModelToSruct());

        }

        private void SaveStore()
        {
            StoreDataService.SaveData(_store.ModelToSruct());
        }

        private void SaveSCode()
        {
            SCodeDataService.SaveData(_sCode.ModelToSruct());
        }

        private void ResetAll()
        {
            var @sCodeStruct = new SCodeStruct();
            @sCodeStruct.SetDefault();
            SCodeDataService.SaveData(@sCodeStruct);

            var @storeStruct = new StoreStruct();
            @storeStruct.SetDefault();
            StoreDataService.SaveData(@storeStruct);
            
            var @operationSystemStruct = new OperationSystemStruct();
            @operationSystemStruct.SetDefault();
            OperationSystemDataService.SaveData(@operationSystemStruct);
            
            SceneManager.LoadScene(Scenes.BootMenu.ToString());
        }
    }
}