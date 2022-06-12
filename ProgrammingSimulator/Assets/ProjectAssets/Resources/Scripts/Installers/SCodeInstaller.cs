using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Models;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class SCodeInstaller : MonoInstaller
    {
        [SerializeField] private List<TextAsset> _binaryCode;

        public override void InstallBindings()
        {
            Container.Bind<SCode>().FromInstance(new SCode(_binaryCode)).AsSingle();
        }
    }
}