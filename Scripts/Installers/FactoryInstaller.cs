using System;
using Character;
using Factories;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        [SerializeField] private LootFactory lootFactory;

        public override void InstallBindings()
        {
            Container.Bind<LootFactory>().FromInstance(lootFactory).AsSingle().NonLazy();
        }
    }
}