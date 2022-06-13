using ModestTree;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.OS
{
    public class ProgressController : MonoBehaviour
    {
        private GameObject _progressBar;
        private GameObject _noProgress;
        private OperationSystem _os;

        [Inject]
        private void Construct(OperationSystem os)
        {
            _os = os;
        }

        private void OnEnable()
        {
            _progressBar = transform.Find(Views.ProgressBar.ToString()).Find(Views.Content.ToString()).gameObject;
            _noProgress = transform.Find(Views.Label.ToString()).gameObject;
            EventHandler.OperationSystem.AddListener(UpdateProgress);
        }

        private void UpdateProgress()
        {
            _noProgress.SetActive(_os.Tasks.IsEmpty());
            _progressBar.SetActive(!_os.Tasks.IsEmpty());
        }
    }
}