using System;
using Interfaces;
using UnityEngine;

namespace Character
{
    public class PlayerInputService : MonoBehaviour, IInputService
    {
        // TODO: move all keys to Actions
        public event Action ActionButtonPressed;

        public event Action AttackButtonPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ActionButtonPressed?.Invoke();
            }

            if (Input.GetMouseButtonDown(0))
            {
                AttackButtonPressed?.Invoke();
            }
        }
        
        public float GetHorizontalAxisValue()
        {
            return Input.GetAxis("Horizontal");
        }

        public float GetVerticalAxisValue()
        {
            return Input.GetAxis("Vertical");
        }
        
        public bool IsMovementControlKeysDown()
        {
            return Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) ||
                   Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);
        }

        public bool IsReturnKeyPressed()
        {
            return Input.GetKeyDown(KeyCode.Escape);
        }
    }
}