using UnityEngine;

namespace DBH.Input.api.Extending {
    public abstract class DirectionInputSystem : AbstractInputSystem, IDirectionInputSystem {
        private Vector2 lastInput;

        public void FixedUpdate() {
            if (!Enabled) return;
            if (lastInput != InputRaw()) {
                InputChanged(InputRaw());
            }

            InputRawNormalized(InputNormalized());
            InputRaw(InputRaw());
            lastInput = InputNormalized();
        }

        protected virtual void InputChanged(Vector2 input) {
        }

        protected virtual void InputRaw(Vector2 input) {
        }

        protected virtual void InputRawNormalized(Vector2 input) {
        }

        private Vector2 InputRaw() {
            var inputX = UnityEngine.Input.GetAxisRaw("Horizontal");
            var inputY = UnityEngine.Input.GetAxisRaw("Vertical");
            return new Vector2(inputX, inputY);
        }

        private Vector2 InputNormalized() {
            return InputRaw().normalized;
        }
    }
}