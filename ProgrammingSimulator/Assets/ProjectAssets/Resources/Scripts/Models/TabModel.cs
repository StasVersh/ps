using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class TabModel
    {
        public Button Button { get; }
        public int Index { get; }
        public GameObject Page { get; }

        public TabModel(Button button, int index, GameObject page)
        {
            Button = button;
            Index = index;
            Page = page;
        }
    }
}