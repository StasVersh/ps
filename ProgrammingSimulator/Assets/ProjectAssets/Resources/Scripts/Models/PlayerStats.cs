using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Values;

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
    }
}