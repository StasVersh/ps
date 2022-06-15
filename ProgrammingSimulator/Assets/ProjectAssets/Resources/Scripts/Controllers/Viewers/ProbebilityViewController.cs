using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ProbebilityViewController : MonoBehaviour
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
            _text.text = Mathf.Round(_sCode.Probability * 100) + "%";
        }
    }
}