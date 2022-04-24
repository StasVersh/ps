using System;
using ProjectAssets.Resources.Scripts.Values;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class Player
    {
        public int SCD { get; private set; }
        public UnityEvent OnValueChanged { get; set; }
        public int Step { get; } = 5;
        public int Rate { get; } = 5;
        public string BinaryCode { get; } = Languages.BinaryCode;
        public int GuaranteedCompilation { get; } = 350;

        public Player()
        {
            Update();
            OnValueChanged = new UnityEvent();
            OnValueChanged.Invoke();
        }

        public void Increment(int count)
        {
            SCD += count * Rate;
            PlayerPrefs.SetInt(Preferences.Coins, SCD);
            OnValueChanged.Invoke();
        }
        public void Decrement(int cost)
        {
            SCD -= cost;
            PlayerPrefs.SetInt(Preferences.Coins, SCD);
            OnValueChanged.Invoke();
        }

        public void Update()
        {
            SCD = PlayerPrefs.GetInt(Preferences.Coins);
        }
    }
}