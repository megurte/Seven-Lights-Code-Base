using System;
using Character;
using Character.Inventory;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInputService playerInputService;
        [SerializeField] private Player player;
        [SerializeField] private Transform spawnPoint;

        public override void InstallBindings()
        {
            Container.Bind<PlayerInputService>().FromInstance(playerInputService).AsSingle().NonLazy();
            Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();

            /*var playerInstance =
                Container.InstantiatePrefabForComponent<CharacterMovementController>(player.gameObject, 
                    spawnPoint.position, 
                    Quaternion.identity, 
                    null);*/
            
            Container.Bind<InventoryModule>().FromInstance(player.GetComponent<InventoryModule>()).AsSingle().NonLazy();
        }
    }
}