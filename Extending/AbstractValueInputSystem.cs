using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DBH.Input.api.Extending {
    public abstract class AbstractValueInputSystem<T> : IIDisposableInputSystem where T : struct {
        public delegate void ButtonPressed(T value);

        public delegate void ButtonCancel();

        public event ButtonPressed OnButtonPressed;
        public event ButtonCancel OnButtonCanceled;
        private readonly InputAction inputAction;

        protected abstract string Path { get; }

        protected AbstractValueInputSystem() {
            inputAction = InputSystem.actions.FindAction(Path);
            if (inputAction == null) {
                Debug.LogError("missing Input Action For:" + Path);
            } else {
                inputAction.performed += OnButtonPerformed;
                inputAction.canceled += OnButtonCancel;
            }
        }

        public void Deconstruct() {
            if (inputAction == null) return;
            inputAction.performed -= OnButtonPerformed;
            inputAction.canceled -= OnButtonCancel;
        }

        private void OnButtonPerformed(InputAction.CallbackContext obj) {
            var readValue = obj.ReadValue<T>();
            OnButtonPressed?.Invoke(readValue);
        }

        private void OnButtonCancel(InputAction.CallbackContext obj) {
            OnButtonCanceled?.Invoke();
        }

        public void Enable() {
            inputAction.Enable();
        }

        public void Disable() {
            inputAction.Disable();
        }
    }
}