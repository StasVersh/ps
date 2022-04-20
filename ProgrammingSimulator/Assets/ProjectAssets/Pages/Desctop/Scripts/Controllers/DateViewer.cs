using System;
using TMPro;
using UnityEngine;

namespace ProjectAssets.Pages.Desctop.Scripts.Controllers
{
    public class DateViewer : MonoBehaviour
    {
        private TMP_Text _text;
    
        private void Start()
        {
            _text = gameObject.GetComponent<TMP_Text>();
        }

        private void Update()
        {
            _text.text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}