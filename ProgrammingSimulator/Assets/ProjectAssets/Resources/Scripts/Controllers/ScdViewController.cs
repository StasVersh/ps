using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScdViewController : MonoBehaviour
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
            _text.text = _playerStats.Scd + " SCD";
        }
    }
}
