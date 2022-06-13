using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Structures;
using ProjectAssets.Resources.Scripts.Utilities;
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

        [Inject]
        private void Construct(SCode sCode, Store store, Input input)
        {
            _sCode = sCode;
            _store = store;
            _input = input;
        }

        private void Start()
        {
            _input.ResetAll.AddListener(ResetAll);
            _sCode.StructToModel(SCodeDataService.LoadData());
            EventHandler.SCode.AddListener(Save);
        }

        private void Save()
        {
            SCodeDataService.SaveData(_sCode.ModelToSruct());
        }

        private void ResetAll()
        {
            var @struct = new SCodeStruct();
            @struct.SetDefault();
            SCodeDataService.SaveData(@struct);
            SceneManager.LoadScene(Scenes.BootMenu.ToString());
        }
    }
}