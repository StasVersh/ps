using System;
using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Enums;
using UnityEngine;

namespace ProjectAssets.Resources.Scripts.Structures
{
    [Serializable]
    public struct Language
    {
        public ProgramingLanguages ProgramingLanguages;
        public List<TextAsset> Assets;
    }
}