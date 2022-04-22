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
            Update();
            OnValueChanged = new UnityEvent();
            OnValueChanged.Invoke();
        }

        public void Increment(int count)
        {
            Coins += count;
            PlayerPrefs.SetInt(Preferences.Coins, Coins);
            OnValueChanged.Invoke();
        }
        public void Decrement(int cost)
        {
            Coins -= cost;
            PlayerPrefs.SetInt(Preferences.Coins, Coins);
            OnValueChanged.Invoke();
        }

        public void Update()
        {
            Coins = PlayerPrefs.GetInt(Preferences.Coins);
        }
    }
}