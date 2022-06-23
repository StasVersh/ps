using System.Collections.Generic;
using ProjectAssets.Resources.Scripts.Models;
using ProjectAssets.Resources.Scripts.Structures;
using UnityEngine;
using Zenject;

namespace ProjectAssets.Resources.Scripts.Installers
{
    public class SCodeInstaller : MonoInstaller
    {
        [SerializeField] private List<Language> _languages;

        public override void InstallBindings()
        {
            Container.Bind<SCode>().FromInstance(new SCode(_languages)).AsSingle();
        }
    }
}