using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Utilities;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class PlayerStats
    {
        public int Scd { get; private set; }
        public int TypingSpeed { get; private set; }
        public int ConversionPrice { get; private set; }
        public int Symbols { get; private set; }
        public Experience Experience { get; private set; }
        public ProgramingLanguages ProgramingLanguage { get; private set; }

        public PlayerStats()
        {
            Scd = Prefs.GetScd();
            TypingSpeed = Prefs.GetTypingSpeed();
            ConversionPrice = Prefs.GetConversionPrice();
            Symbols = Prefs.GetSymbols();
            Experience = (Experience)Prefs.GetExperience();
            ProgramingLanguage = (ProgramingLanguages)Prefs.GetProgramingLanguage();
            EventHandler.PlayerPrefs.Invoke();
        }

        public void AccrueScd(int value)
        {
            Scd += value;
            Prefs.SetScd(Scd);
            EventHandler.PlayerPrefs.Invoke();
        }

        public void WriteOffScd(int value)
        {
            if(value > Scd) return;
            Scd -= value;
            Prefs.SetScd(Scd);
            EventHandler.PlayerPrefs.Invoke();
        }

        public void IncreaseConversionPrice(int value)
        {
            ConversionPrice += value;
            Prefs.SetConversionPrice(ConversionPrice);
            EventHandler.PlayerPrefs.Invoke();
        }
        
        public void IncreaseTypingSpeed(int value)
        {
            TypingSpeed += value;
            Prefs.SetTypingSpeed(TypingSpeed);
            EventHandler.PlayerPrefs.Invoke();
        }
        
        public void IncreaseSymbolsByOne()
        {
            Symbols += 1;
            Prefs.SetSymbols(Symbols);
            EventHandler.PlayerPrefs.Invoke();
        }
        
        public void ResetSymbols()
        {
            Symbols = 0;
            Prefs.SetSymbols(Symbols);
            EventHandler.PlayerPrefs.Invoke();
        }
        
        public void IncreaseExperienceLevel()
        {
            Experience += 1;
            Prefs.SetExperience((int)Experience);
            EventHandler.PlayerPrefs.Invoke();
        }
        
        public void IncreaseProgramingLanguages()
        {
            ProgramingLanguage += 1;
            Prefs.SetProgramingLanguage((int)ProgramingLanguage);
            EventHandler.PlayerPrefs.Invoke();
        }
    }
}