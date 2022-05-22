using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class CodeExamplesInstaller : MonoInstaller
    {
        [SerializeField] private List<TextAsset> _binaryCode;
        
        public override void InstallBindings()
        {
            Container.Bind<CodeExamples>().FromInstance(new CodeExamples(_binaryCode)).AsSingle();
        }
    }
}