using System;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class UpdateValuesController : MonoBehaviour
    {
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
            _playerStats.UpdateValuesOnPrefs();
            _store.UpdateValuesOnPrefs();
        }
    }
}