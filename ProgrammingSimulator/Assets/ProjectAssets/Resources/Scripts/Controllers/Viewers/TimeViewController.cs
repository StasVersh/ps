using System;
using TMPro;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Controllers.Viewers
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimeViewController : MonoBehaviour
    {
        private TMP_Text _text;

        private void OnEnable()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
