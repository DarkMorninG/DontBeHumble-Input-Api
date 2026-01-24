using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DBH.Input.api.Extending {
    public abstract class AbstractValueInputSystem<T> where T : struct {
        public delegate void ButtonPressed(T value);

        public event ButtonPressed OnButtonPressed;

        protected abstract string Path { get; }

        protected AbstractValueInputSystem() {
            var inputAction = InputSystem.actions.FindAction(Path);
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
    }
}