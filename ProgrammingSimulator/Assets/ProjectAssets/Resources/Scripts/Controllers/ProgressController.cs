using ModestTree;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    public class ProgressController : MonoBehaviour
    {
        private GameObject _progressBar;
        private GameObject _noProgress;
        private PlayerStats _playerStats;

        [Inject]
        private void Construct(PlayerStats playerStats)
        {
            _playerStats = playerStats;
        }

        private void OnEnable()
        {
            _progressBar = transform.Find(Views.ProgressBar.ToString()).Find(Views.Content.ToString()).gameObject;
            _noProgress = transform.Find(Views.Label.ToString()).gameObject;
            EventHandler.PlayerPrefs.AddListener(UpdateProgress);
        }

        private void UpdateProgress()
        {
            _noProgress.SetActive(_playerStats.Tasks.IsEmpty());
            _progressBar.SetActive(!_playerStats.Tasks.IsEmpty());
        }
    }
}