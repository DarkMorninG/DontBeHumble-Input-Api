using UnityEngine;
using UnityEngine.InputSystem;

namespace DBH.Input.api.Extending {
    public abstract class AbstractButtonInputSystem {
        public delegate void ButtonPressed();

        public event ButtonPressed OnButtonPressed;

        protected abstract string Path { get; }

        protected AbstractButtonInputSystem() {
            var inputAction = InputSystem.actions.FindAction(Path);
            if (inputAction == null) {
                Debug.LogError("missing Input Action For:" + Path);
            } else {
                inputAction.performed += OnButtonPerformed;
            }
        }

        private void OnButtonPerformed(InputAction.CallbackContext obj) {
            OnButtonPressed?.Invoke();
        }
    }
}