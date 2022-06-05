using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ProcessLeftController : MonoBehaviour
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
            _text.text = _playerStats.Tasks.Count.ToString();
        }
    }
}