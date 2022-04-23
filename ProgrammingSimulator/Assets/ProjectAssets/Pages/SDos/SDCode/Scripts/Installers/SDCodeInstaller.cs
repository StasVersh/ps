using Michsky.UI.ModernUIPack;
using ProjectAssets.Pages.SDos.SDCode.Scripts.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ProjectAssets.Pages.SDos.SDCode.Scripts.Installers
{
    public class SDCodeInstaller : MonoInstaller
    {
        [SerializeField] private TMP_Text _code;
        [SerializeField] private TMP_Text _symbols;
        [SerializeField] private ScrollRect _scrolling;
        [SerializeField] private Button _buildButton;
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private ModalWindowManager _doneCompilationWindow;

        public override void InstallBindings()
        {
            Container.Bind<SDCodeModel>().FromInstance(new SDCodeModel(_code, _symbols, _scrolling, _buildButton, _progressBar, _doneCompilationWindow)).AsSingle().NonLazy();
        }
    }
}