using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class ProcessLeftController : MonoBehaviour
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
            EventHandler.SCode.AddListener(UpdateText);
            UpdateText();
        }
        
        private void UpdateText()
        {
            _text.text = _os.Tasks.Count.ToString();
        }
    }
}