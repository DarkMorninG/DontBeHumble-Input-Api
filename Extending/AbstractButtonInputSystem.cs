using UnityEngine;
using UnityEngine.InputSystem;

namespace DBH.Input.api.Extending {
    public abstract class AbstractButtonInputSystem {
        public delegate void ButtonInput();

        public event ButtonInput OnButtonPerformed;
        public event ButtonInput OnButtonStarted;
        public event ButtonInput OnButtonCanceled;

        protected abstract string Path { get; }

        protected AbstractButtonInputSystem() {
            var inputAction = InputSystem.actions.FindAction(Path);
            if (inputAction == null) {
                Debug.LogError("missing Input Action For:" + Path);
            } else {
                inputAction.performed += ButtonPerformed;
                inputAction.started += ButtonStarted;
                inputAction.canceled += ButtonCanceled;
            }
        }

        private void ButtonPerformed(InputAction.CallbackContext obj) {
            OnButtonPerformed?.Invoke();
        }
        private void ButtonStarted(InputAction.CallbackContext obj) {
            OnButtonStarted?.Invoke();
        }
        private void ButtonCanceled(InputAction.CallbackContext obj) {
            OnButtonCanceled?.Invoke();
        }
    }
}