using System.Collections.Generic;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Models
{
    public class CodeExamples
    {
        public List<TextAsset> BinaryCode { get; }
        
        public CodeExamples(List<TextAsset> binaryCode)
        {
            BinaryCode = binaryCode;
        }
    }
}