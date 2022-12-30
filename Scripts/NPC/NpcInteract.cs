using Interfaces;
using UnityEngine;
using Zenject;

namespace NPC
{
    public abstract class NpcInteract : MonoBehaviour, IInteractable
    {
        public abstract void ReleaseAction();
    }
}