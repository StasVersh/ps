using System;
using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;
using ListTile = ProjectAssets.Resources.Scripts.Scriptable.ListTile;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class StoreListViewController : MonoBehaviour
    {
        [SerializeField] private GameObject _listTilePrefab;
        [SerializeField] private List<ListTile> ListTiles;
        
        private PlayerStats _playerStats;
        private Store _store;

        [Inject]
        private void Construct(PlayerStats playerStats, Store store)
        {
            _playerStats = playerStats;
            _store = store;
        }

        private void Start()
        {
            EventHandler.PlayerPrefs.AddListener(UpdateList);
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
                listTileController.Coast.text = $"{listTile.GetCoast()} SCD";
                listTile.IsEnable = listTile.GetCoast() <= _playerStats.Scd;
                listTileController.CoastButton.interactable = listTile.IsEnable;
                listTileController.ListTileButton.interactable = listTile.IsEnable;
                listTile.Bay = listTileController.CoastButton.onClick;
                listTile.Bay.AddListener(() => {Baying(listTile);});
            }
        }
    
        private void Baying(ListTile listTile)
        {
            if (!_playerStats.WriteOffScd(listTile.GetCoast())) return;
            Action(listTile.Action);
            UpdateList();
        }

        private void Action(StorePoints points)
        {
            switch (points)
            {
                case StorePoints.TypingSpeed:
                    _playerStats.IncreaseTypingSpeed(1);
                    _store.IncreaseTypingSpeedLevel();
                    break;
                case StorePoints.BookOnProgramming:
                    _playerStats.IncreaseExperienceLevel();
                    _store.IncreaseBookOnProgrammingLevel();
                    break;
                case StorePoints.CourseOurSelfPrice:
                    _playerStats.IncreaseConversionPrice(1);
                    _store.IncreaseCourseOurSelfPriceLevel();
                    break;
                case StorePoints.NewProcessor:
                    _playerStats.IncreaseBuildingSpeed();
                    _store.IncreaseBuildingSpeedLevel();
                    break;
            }
        }
    }
}