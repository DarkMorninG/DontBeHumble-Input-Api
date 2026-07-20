using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DBH.Input.api.Extending {
    public abstract class AbstractValueInputSystem<T> : IIDisposableInputSystem where T : struct {
        public delegate void ButtonPressed(T value);

        public event ButtonPressed OnButtonPerformed;
        public event ButtonPressed OnButtonStarted;
        public event ButtonPressed OnButtonCanceled;
        private readonly InputAction inputAction;

        protected abstract string Path { get; }

        protected AbstractValueInputSystem() {
            inputAction = InputSystem.actions.FindAction(Path);
            if (inputAction == null) {
                Debug.LogError("missing Input Action For:" + Path);
            } else {
                inputAction.started += ButtonStarted;
                inputAction.performed += ButtonPerformed;
                inputAction.canceled += ButtonCancel;
            }
        }

        public void Deconstruct() {
            if (inputAction == null) return;
            inputAction.performed -= ButtonPerformed;
            inputAction.canceled -= ButtonCancel;
            inputAction.started -= ButtonStarted;
        }

        private void ButtonPerformed(InputAction.CallbackContext obj) {
            var readValue = obj.ReadValue<T>();
            OnButtonPerformed?.Invoke(readValue);
        }

        private void ButtonStarted(InputAction.CallbackContext obj) {
            var readValue = obj.ReadValue<T>();
            OnButtonStarted?.Invoke(readValue);
        }

        private void ButtonCancel(InputAction.CallbackContext obj) {
            var readValue = obj.ReadValue<T>();
            OnButtonCanceled?.Invoke(readValue);
        }

        public void Enable() {
            inputAction.Enable();
        }

        public void Disable() {
            inputAction.Disable();
        }
    }
}