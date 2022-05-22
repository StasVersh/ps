using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class SymbolsViewController : MonoBehaviour
    {
        private TMP_Text _text;
        private PlayerStats _playerStats;

        [Inject]
        private void Construct(PlayerStats playerStats)
        {
            _playerStats = playerStats;
            EventHandler.PlayerPrefs.AddListener(UpdateText);
        }

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            UpdateText();
        }
        
        private void UpdateText()
        {
            _text.text = _playerStats.Symbols.ToString();
        }
    }
}
