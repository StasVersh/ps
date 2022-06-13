using System;
using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Enums;
using ProjectAssets.Resources.Scripts.Structures;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class SCode
    {
        public int TypingSpeed { get; private set; }
        public int ConversionPrice { get; private set; }
        public long Symbols { get; private set; }
        public int GuaranteedCode { get; private set; }    
        public Experience Experience { get; private set; } 
        public ProgramingLanguages ProgramingLanguage { get; private set; }
        public List<TextAsset> BinaryCode { get; }

        public SCode(List<TextAsset> binaryCode)
        {
            TypingSpeed = 1;
            ConversionPrice = 1;
            Symbols = 0;
            GuaranteedCode = 250;
            Experience = 0;
            ProgramingLanguage = 0;
            BinaryCode = binaryCode;
        }

        public void StructToModel(SCodeStruct @struct)
        {
            TypingSpeed = @struct.TypingSpeed;
            ConversionPrice = @struct.ConversionPrice;
            Symbols = @struct.Symbols;
            GuaranteedCode = @struct.GuaranteedCode;    
            Experience = (Experience)@struct.Experience;
            ProgramingLanguage = (ProgramingLanguages)@struct.ProgramingLanguage;
            EventHandler.SCode.Invoke();
        }
        
        public SCodeStruct ModelToSruct()
        {
            return new SCodeStruct
            {
                TypingSpeed = TypingSpeed,
                ConversionPrice = ConversionPrice,
                Symbols = Symbols,
                GuaranteedCode = GuaranteedCode,
                Experience = (int)Experience,
                ProgramingLanguage = (int)ProgramingLanguage
            };
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