using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.Viewers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ExperienceViewController : MonoBehaviour
    {
        private TMP_Text _text;
        private Store _store;

        [Inject]
        private void Construct(Store store)
        {
            _store = store;
        }

        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
            EventHandler.SCode.AddListener(UpdateText);
            UpdateText();
        }
        
        private void UpdateText()
        {
            _text.text = ((Experience)_store.BookOnProgrammingLevel).ToString();
        }
    }
}
