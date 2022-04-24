using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Values;
using TMPro;
using UnityEditor;
using UnityEngine.UI;

namespace ProjectAssets.Pages.SDos.SDCode.Scripts.Models
{
    public class SDCodeModel
    {
        public SDCodeUI UI { get; }
        public SDCodeModel(SDCodeUI ui)
        {
            UI = ui;
        }
    }
}