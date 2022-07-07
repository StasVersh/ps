using System;
using ProjectAssets.Resources.Scripts.Models;
using TMPro;
using UnityEngine;
using EventHandler = ProjectAssets.Resources.Scripts.Models.EventHandler;

namespace ProjectAssets.Resources.Scripts.Controllers.SCodeApp
{
    [RequireComponent(typeof(TMP_Text))]
    public class LineNumbersController : MonoBehaviour
    {
        private TMP_Text _text;

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
            UpdateText(null);
            EventHandler.BuildingEnd.AddListener(UpdateText);
        }

        private void UpdateText(Building arg0)
        {
            _text.text = string.Empty;
            for (var i = 0; i < 999; i++)
            {
                _text.text += (i + 1) + "\n";
            }
        }
    }
}