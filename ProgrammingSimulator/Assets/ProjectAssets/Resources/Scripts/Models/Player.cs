using System;
using ProjectAssets.Resources.Scripts.Values;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Player
    {
        public int Coins { get; private set; }
        public UnityEvent OnValueChanged { get; set; }
        public int Step { get; set; }

        public Player()
        {
            Coins = PlayerPrefs.GetInt(Preferences.Coins);
            OnValueChanged = new UnityEvent();
            OnValueChanged.Invoke();
        }

        public void Increment()
        {
            Coins += Step;
            PlayerPrefs.SetInt(Preferences.Coins, Coins);
            OnValueChanged.Invoke();
        }
    }
}