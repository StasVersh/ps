using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.Viewers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ConversionViewController : MonoBehaviour
    {
        private TMP_Text _text;
        private SCode _sCode;

        [Inject]
        private void Construct(SCode sCode)
        {
            _sCode = sCode;
        }

        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
            EventHandler.SCode.AddListener(UpdateText);
            UpdateText();
        }
        
        private void UpdateText()
        {
            _text.text = 1 + "/" + ((int)_sCode.ProgramingLanguage + 1);
        }
    }
}
