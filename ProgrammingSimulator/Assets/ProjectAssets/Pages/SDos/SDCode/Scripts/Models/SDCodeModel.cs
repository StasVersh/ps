using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine.UI;

namespace ProjectAssets.Pages.SDos.SDCode.Scripts.Models
{
    public class SDCodeModel
    {
        public TMP_Text Code { get; }
        public TMP_Text Symbols { get; }
        public ScrollRect Scrolling { get; }
        public Button BuildButton { get; }
        public ProgressBar ProgressBar { get; }
        public ModalWindowManager DoneCompilationWindow { get; }

        public SDCodeModel(TMP_Text code, TMP_Text symbols, ScrollRect scrolling, Button buildButton, ProgressBar progressBar, ModalWindowManager doneCompilationWindow)
        {
            Code = code;
            Symbols = symbols;
            Scrolling = scrolling;
            BuildButton = buildButton;
            ProgressBar = progressBar;
            DoneCompilationWindow = doneCompilationWindow;
        }
    }
}