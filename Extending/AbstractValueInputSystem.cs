using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DBH.Input.api.Extending {
    public abstract class AbstractValueInputSystem<T> where T : struct {
        public delegate void ButtonPressed(T value);

        public event ButtonPressed OnButtonPressed;
        private readonly InputAction inputAction;

        protected abstract string Path { get; }

        protected AbstractValueInputSystem() {
            inputAction = InputSystem.actions.FindAction(Path);
            if (inputAction == null) {
                Debug.LogError("missing Input Action For:" + Path);
            } else {
                inputAction.performed += OnButtonPerformed;
            }
        }

        private void OnButtonPerformed(InputAction.CallbackContext obj) {
            var readValue = obj.ReadValue<T>();
            OnButtonPressed?.Invoke(readValue);
        }

        public void Enable() {
            inputAction.Enable();
        }

        public void Disable() {
            inputAction.Disable();
        }
    }
}