using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Structures;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class SCode
    {
        public int TypingSpeed { get; private set; }
        public int Symbols  { get; private set; }
        public int GuaranteedCode  { get; private set; }
        public float Probability { get; private set; }    
        public Experience Experience { get; private set; } 
        public ProgramingLanguages ProgramingLanguage { get; private set; }
        public List<Language> LanguagesAssets { get; }

        public SCode(List<Language> languagesAssets)
        {
            TypingSpeed = 1;
            Symbols = 0;
            Experience = 0;
            ProgramingLanguage = 0;
            LanguagesAssets = languagesAssets;
            UpdateGuaranteedCode();
            UpdateProbability();
        }

        public void StructToModel(SCodeStruct @struct)
        {
            TypingSpeed = @struct.TypingSpeed;
            Symbols = @struct.Symbols;
            Experience = (Experience)@struct.Experience;
            ProgramingLanguage = (ProgramingLanguages)@struct.ProgramingLanguage;
            UpdateProbability();
            UpdateGuaranteedCode();
            EventHandler.SCode.Invoke();
            EventHandler.ProgrammingLanguage.Invoke();
        }
        
        public SCodeStruct ModelToSruct()
        {
            return new SCodeStruct
            {
                TypingSpeed = TypingSpeed,
                Symbols = Symbols,
                Experience = (int)Experience,
                ProgramingLanguage = (int)ProgramingLanguage
            };
        }

        public void IncreaseTypingSpeed(int value)
        {
            TypingSpeed += value;
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseSymbolsByOne()
        {
            Symbols += 1;
            UpdateProbability();
            EventHandler.SCode.Invoke();
        }
        
        public void ResetSymbols()
        {
            Symbols = 0;
            UpdateProbability();
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseExperienceLevel()
        {
            Experience += 1;
            UpdateGuaranteedCode();
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseProgramingLanguages()
        {
            ProgramingLanguage += 1;
            EventHandler.ProgrammingLanguage.Invoke();
            EventHandler.SCode.Invoke();
        }

        private void UpdateGuaranteedCode()
        {
            var coast = 250;
            for (var i = 0; i < (int)Experience; i++)
            {
                coast *= 2;
            }
            GuaranteedCode = coast;
        }

        private void UpdateProbability()
        {
            var probability = (float)GuaranteedCode / Symbols;
            Probability = probability > 1 ? 1 : probability;
        }
    }
}