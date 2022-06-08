using System.Linq;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(Button))]
    public class StartBuildButtonController : MonoBehaviour
    {
        private Button _button;
        private PlayerStats _playerStats;

        [Inject]
        private void Construct(PlayerStats playerStats, Input input)
        {
            _playerStats = playerStats;
            input.Build.AddListener(OnButtonClick);
        }
        
        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            var canStart = true;
            foreach (var task in _playerStats.Tasks.Where(task => canStart))
            {
                canStart = !(task is Building);
            }
            if(canStart && _playerStats.Symbols > 0) _playerStats.AddTask(new Building(_playerStats.BuildingSpeed));
        }
    }
}