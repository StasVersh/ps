using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Controllers.SCodeApp
{
    [RequireComponent(typeof(ProgressBar))]
    public class SymbolsProgressBarController : MonoBehaviour
    {
        private ProgressBar _progressBar;
        private SCode _sCode;

        [Inject]
        private void Construct(SCode sCode)
        {
            _sCode = sCode;
        }

        private void OnEnable()
        {
            _progressBar = GetComponent<ProgressBar>();
            EventHandler.SCode.AddListener(UpdateProgressBar);
        }

        private void UpdateProgressBar()
        {
            _progressBar.maxValue = _sCode.GuaranteedCode;
            if(_sCode.Symbols <= _sCode.GuaranteedCode) 
                _progressBar.currentPercent = _sCode.Symbols;
            _progressBar.UpdateUI();
        }
    }
}