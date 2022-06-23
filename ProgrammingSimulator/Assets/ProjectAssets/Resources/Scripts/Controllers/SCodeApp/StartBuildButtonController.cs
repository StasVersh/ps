using System.Linq;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Input = ProjectAssets.Resources.Scripts.Models.Input;

namespace ProjectAssets.Resources.Scripts.Controllers.SCodeApp
{
    [RequireComponent(typeof(Button))]
    public class StartBuildButtonController : MonoBehaviour
    {
        private Button _button;
        private OperationSystem _os;
        private SCode _sCode;

        [Inject]
        private void Construct(OperationSystem os, Input input, SCode sCode)
        {
            _os = os;
            _sCode = sCode;
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
            foreach (var task in _os.Tasks.Where(task => canStart))
            {
                canStart = !(task is Building);
            }

            if (!canStart || _sCode.Symbols <= 0) return;
            
            var isSuccessfully = Random.Range(0, 100) < Mathf.Round(_sCode.Probability * 100);
            _os.AddTask(new Building(_os.BuildingSpeed, _sCode.Symbols, (int)_sCode.ProgramingLanguage + 1, _sCode.Probability, isSuccessfully));
            _sCode.ResetSymbols();
        }
    }
}