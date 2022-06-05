using System.Linq;
using Michsky.UI.ModernUIPack;
using ModestTree;
using ProjectAssets.Resources.Scripts.Models;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class ProgressBarController : MonoBehaviour
    {
        private ProgressBar _progressBar;
        private PlayerStats _playerStats;

        [Inject]
        private void Construct(PlayerStats playerStats)
        {
            _playerStats = playerStats;
        }

        private void OnEnable()
        {
            _progressBar = GetComponent<ProgressBar>();
            EventHandler.PlayerPrefs.AddListener(UpdateProgressBar);
        }

        public void OnProgressBarChanged(float value)
        {
            if (value < 100) return;
            var task = _playerStats.Tasks.First();
            task.End(_playerStats);
            _progressBar.currentPercent = 0;
            _progressBar.isOn = false;
            _progressBar.UpdateUI();
            _playerStats.RemoveTask();
        }

        private void UpdateProgressBar()
        {
            if(_progressBar.isOn) return;
            if(_playerStats.Tasks.IsEmpty()) return;
            var task = _playerStats.Tasks.First();
            _progressBar.speed = task.Speed;
            _progressBar.prefix = task.Name + "... ";
            _progressBar.isOn = true;
            _progressBar.UpdateUI();
        }
    }
}