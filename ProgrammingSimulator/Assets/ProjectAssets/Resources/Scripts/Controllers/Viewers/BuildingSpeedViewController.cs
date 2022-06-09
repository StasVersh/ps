using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.Viewers
{
    [RequireComponent(typeof(TMP_Text))]
    public class BuildingSpeedViewController : MonoBehaviour
    {
        private TMP_Text _text;
        private PlayerStats _playerStats;

        [Inject]
        private void Construct(PlayerStats playerStats)
        {
            _playerStats = playerStats;
        }

        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
            EventHandler.PlayerPrefs.AddListener(UpdateText);
            UpdateText();
        }
        
        private void UpdateText()
        {
            _text.text = (_playerStats.BuildingSpeed / 5).ToString();
        }
    }
}
