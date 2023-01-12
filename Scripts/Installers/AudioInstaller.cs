using Scene;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class AudioInstaller : MonoInstaller
    {
        [SerializeField] private AudioService audioService;

        public override void InstallBindings()
        {
            Container.Bind<AudioService>().FromInstance(audioService).AsSingle().NonLazy();
        }
    }
}