using System.Linq;
using Michsky.UI.ModernUIPack;
using ModestTree;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.OS
{
    public class ProgressBarController : MonoBehaviour
    {
        private ProgressBar _progressBar;
        private OperationSystem _os;

        [Inject]
        private void Construct(OperationSystem os)
        {
            _os = os;
        }

        private void OnEnable()
        {
            _progressBar = GetComponent<ProgressBar>();
            EventHandler.OperationSystem.AddListener(UpdateProgressBar);
        }

        public void OnProgressBarChanged(float value)
        {
            if (value < 100) return;
            var task = _os.Tasks.First();
            task.End(_os);
            _progressBar.currentPercent = 0;
            _progressBar.isOn = false;
            _progressBar.UpdateUI();
            if (task is Building building) EventHandler.BuildingEnd.Invoke(building);
                _os.RemoveTask();
        }

        private void UpdateProgressBar()
        {
            if(_progressBar.isOn) return;
            if(_os.Tasks.IsEmpty()) return;
            var task = _os.Tasks.First();
            _progressBar.speed = task.Speed;
            _progressBar.prefix = task.Name + "... ";
            _progressBar.isOn = true;
            _progressBar.UpdateUI();
        }
    }
}