using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectAssets.Pages.Notepad.Scripts.Models
{
    public class Code
    {
        public GameObject GameObject { get; }
        public ScrollRect ScrollRect { get; }
        public TMP_Text Text { get; }
        public Code(GameObject gameObject, ScrollRect scrollView)
        {
            GameObject = gameObject;
            ScrollRect = scrollView;
            Text = GameObject.GetComponent<TMP_Text>();
        }
    }
}