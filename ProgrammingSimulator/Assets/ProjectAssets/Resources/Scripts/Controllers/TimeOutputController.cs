using System;
using TMPro;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Controllers
{
    [RequireComponent(typeof(TMP_Text))]
    public class TimeOutputController : MonoBehaviour
    {
        private TMP_Text _text;
        
        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = DateTime.Now.ToString("hh:mm:ss");
        }
    }
}
