using System;
using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Utilities;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;
using ListTile = ProjectAssets.Resources.Scripts.Scriptable.ListTile;

namespace ProjectAssets.Resources.Scripts.Controllers.StoreApp
{
    public class StoreListViewController : MonoBehaviour
    {
        [SerializeField] private GameObject _listTilePrefab;
        [SerializeField] private List<ListTile> ListTiles;
        
        private SCode _sCode;
        private Store _store;
        private OperationSystem _os;

        [Inject]
        private void Construct(SCode sCode, Store store, OperationSystem os)
        {
            _sCode = sCode;
            _store = store;
            _os = os;
        }

        private void Start()
        {
            EventHandler.OperationSystem.AddListener(UpdateList);
            EventHandler.Store.AddListener(UpdateList);
            UpdateList();
        }

        private void UpdateList()
        {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }

            foreach (var listTile in ListTiles)
            {
                var tileObject = Instantiate(_listTilePrefab, transform.position, Quaternion.identity, transform);
                var listTileController = tileObject.GetComponent<ListTileController>();
                listTile.Level = _store.GetValueOnType(listTile.Action);
                listTileController.Level.text = $"Lvl. {listTile.Level}";
                listTileController.Header.text = listTile.Header;
                listTileController.Description.text = listTile.Description;
                listTileController.Coast.text = $"{CoinsConvertor.ToMinString(listTile.GetCoast())} SCD";
                listTile.IsEnable = listTile.GetCoast() <= _os.Scd;
                listTileController.CoastButton.interactable = listTile.IsEnable;
                listTileController.ListTileButton.interactable = listTile.IsEnable;
                listTile.Bay = listTileController.CoastButton.onClick;
                listTile.Bay.AddListener(() => {Baying(listTile);});
            }
        }
    
        private void Baying(ListTile listTile)
        {
            if (!_os.WriteOffScd(listTile.GetCoast())) return;
            Action(listTile.Action);
            UpdateList();
        }

        private void Action(StorePoints points)
        {
            switch (points)
            {
                case StorePoints.TypingSpeed:
                    _sCode.IncreaseTypingSpeed(1);
                    _store.IncreaseTypingSpeedLevel();
                    break;
                case StorePoints.BookOnProgramming:
                    _sCode.IncreaseExperienceLevel();
                    _store.IncreaseBookOnProgrammingLevel();
                    break;
                case StorePoints.CourseOurSelfPrice:
                    _sCode.IncreaseConversionPrice(1);
                    _store.IncreaseCourseOurSelfPriceLevel();
                    break;
                case StorePoints.NewProcessor:
                    _os.IncreaseBuildingSpeed();
                    _store.IncreaseBuildingSpeedLevel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(points), points, null);
            }
        }
    }
}