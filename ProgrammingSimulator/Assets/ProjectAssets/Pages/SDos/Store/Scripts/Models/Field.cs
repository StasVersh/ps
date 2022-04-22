using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Values;
using TMPro;
using UnityEngine;

namespace ProjectAssets.Pages.SDos.Store.Scripts.Models
{
    public class Field
    {
        public TMP_Text Title { get; }
        public TMP_Text Description { get; }
        public TMP_Text LevelText { get; }
        public ButtonManager Button { get; }
        public string LevelPrefix { get; }
        public string CostPostfix { get; set; }
        public List<string> Titles { get; }
        public List<string> Descriptions { get; }
        public List<int> Costs { get; }
        
        public int CurrentLevel { get; private set; }
        
        public Field(TMP_Text title, TMP_Text description, TMP_Text levelText, ButtonManager button, List<string> titles, List<string> descriptions, List<int> costs, string levelPrefix)
        {
            Title = title;
            Description = description;
            LevelText = levelText;
            Button = button;
            Titles = titles;
            Descriptions = descriptions;
            Costs = costs;
            LevelPrefix = levelPrefix;
            CurrentLevel = PlayerPrefs.GetInt(Preferences.CoursesLevel);
            UpdateUI();
        }

        public void GrowUpLevel(Player player)
        {
            if (CurrentLevel != Costs.Count - 1)
            {
                player.Decrement(Costs[CurrentLevel]);
                CurrentLevel++;
                PlayerPrefs.SetInt(Preferences.CoursesLevel, CurrentLevel);
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            LevelText.text = $"{LevelPrefix} {CurrentLevel}";
            Title.text = Titles[CurrentLevel];
            Description.text = Descriptions[CurrentLevel];
            Button.buttonText = $"{Costs[CurrentLevel].ToString()} {CostPostfix}";
        }
    }
}