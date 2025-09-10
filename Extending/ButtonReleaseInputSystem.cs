using System;
using Cysharp.Threading.Tasks;
using Vault.BetterCoroutine;

namespace DBH.Input.api.Extending {
    public abstract class ButtonInputSystem : AbstractInputSystem, IButtonInputSystem {
        private IAsyncRuntime buttonReleasedDelay;
        private IAsyncRuntime buttonPressedDelay;

        public void KeyReleased() {
            if (!Enabled) return;
            if (buttonReleasedDelay.IsNotRunning()) {
                buttonReleasedDelay = AsyncRuntime.Create(ButtonDelay(OnKeyReleased));
            } else {
                buttonReleasedDelay.AndAfterFinishDo(() => buttonReleasedDelay = AsyncRuntime.Create(ButtonDelay(OnKeyReleased)));
            }
        }

        public void KeyPressed() {
            if (!Enabled) return;
            if (buttonPressedDelay.IsNotRunning()) {
                buttonPressedDelay = AsyncRuntime.Create(ButtonDelay(OnKeyPressed));
            } else {
                buttonPressedDelay.AndAfterFinishDo(() => buttonPressedDelay = AsyncRuntime.Create(ButtonDelay(OnKeyPressed)));
            }
        }


        public abstract void OnKeyReleased();

        public virtual void OnKeyPressed() {
            
        }

        private async UniTask ButtonDelay(Action onConfirm) {
            onConfirm?.Invoke();
            await UniTask.Delay(TimeSpan.FromSeconds(.2f), DelayType.Realtime);
        }
    }
}