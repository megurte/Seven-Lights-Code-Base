using System;
using Interfaces;
using UnityEngine;
using Zenject;

namespace Character
{
    [RequireComponent(typeof(Collider2D)), RequireComponent(typeof(IInteractable))]
    public class ActionTrigger : MonoBehaviour
    {
        private PlayerInputService _input;
        private IInteractable _interactableSubject;
        
        [Inject]
        private void SetDependency(PlayerInputService inputService)
        {
            _input = inputService;
        }

        private void Start()
        {
            _interactableSubject = GetComponent<IInteractable>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                _input.ActionButtonPressed += SubscribeToAction;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Player player))
            {
                _input.ActionButtonPressed -= SubscribeToAction;
            }
        }

        private void SubscribeToAction()
        {
            _interactableSubject.ReleaseAction();
        }
    }
}