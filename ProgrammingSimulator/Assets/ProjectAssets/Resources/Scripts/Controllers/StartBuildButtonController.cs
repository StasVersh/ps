using System.Linq;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(Button))]
    public class StartBuildButtonController : MonoBehaviour
    {
        private Button _button;
        private PlayerStats _playerStats;

        [Inject]
        private void Construct(PlayerStats playerStats)
        {
            _playerStats = playerStats;
        }
        
        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _playerStats.Tasks.Add(new Building());
            var task = _playerStats.Tasks.First();
            task.End(_playerStats);
            _playerStats.Tasks.Remove(task);
        }
    }
}