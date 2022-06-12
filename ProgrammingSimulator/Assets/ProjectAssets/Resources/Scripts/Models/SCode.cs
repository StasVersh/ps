using System;
using System.Collections.Generic;
using System.Linq;
using ProjectAssets.Resources.Scripts.Enums;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class SCode
    {
        public int TypingSpeed { get; private set; }
        public int ConversionPrice { get; private set; }
        public int Symbols { get; private set; }
        public int GuaranteedCode { get; private set; }    
        public Experience Experience { get; private set; } 
        public ProgramingLanguages ProgramingLanguage { get; private set; }
        public List<TextAsset> BinaryCode { get; }

        public SCode(List<TextAsset> binaryCode)
        {
            BinaryCode = binaryCode;
        }

        public void IncreaseConversionPrice(int value)
        {
            ConversionPrice += value;
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseTypingSpeed(int value)
        {
            TypingSpeed += value;
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseSymbolsByOne()
        {
            Symbols += 1;
            EventHandler.SCode.Invoke();
        }
        
        public void ResetSymbols()
        {
            Symbols = 0;
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseExperienceLevel()
        {
            Experience += 1;
            EventHandler.SCode.Invoke();
        }
        
        public void IncreaseProgramingLanguages()
        {
            ProgramingLanguage += 1;
            EventHandler.SCode.Invoke();
        }

        public void IncreaseGuaranteedCode()
        {
            GuaranteedCode = (int)Math.Round(GuaranteedCode * 1.5);
            EventHandler.SCode.Invoke();
        }
    }
}