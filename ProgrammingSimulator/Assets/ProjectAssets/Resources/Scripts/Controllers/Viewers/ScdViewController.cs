using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Utilities;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.Viewers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ScdViewController : MonoBehaviour
    {
        private TMP_Text _text;
        private OperationSystem _os;

        [Inject]
        private void Construct(OperationSystem os)
        {
            _os = os;
        }

        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
            EventHandler.OperationSystem.AddListener(UpdateText);
            UpdateText();
        }
        
        private void UpdateText()
        {
            _text.text = CoinsConvertor.ToMinString(_os.Scd) + " SCD";
        }
    }
}
