using System;
using BetterCoroutine;
using BetterCoroutine.AwaitRuntime;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Vault.BetterCoroutine;

namespace DBH.Input.api.Extending {
    public abstract class ButtonInputSystem : AbstractInputSystem, IButtonInputSystem {
        private IAwaitRuntime buttonReleasedDelay;
        private IAwaitRuntime buttonPressedDelay;

        public void KeyReleased() {
            if (!Enabled) return;
            if (buttonReleasedDelay.IsNotRunning()) {
                buttonReleasedDelay = IAwaitRuntime.WaitForSeconds(OnKeyReleased, .2f);
            } else {
                buttonReleasedDelay.AndAfterFinishDo(() => buttonReleasedDelay = IAwaitRuntime.WaitForSeconds(OnKeyReleased, .2f));
            }
        }

        public void KeyPressed() {
            if (!Enabled) return;
            if (buttonPressedDelay.IsNotRunning()) {
                buttonPressedDelay = IAwaitRuntime.WaitForSeconds(OnKeyPressed, .2f);
            } else {
                buttonPressedDelay.AndAfterFinishDo(() => buttonPressedDelay = IAwaitRuntime.WaitForSeconds(OnKeyPressed, .2f));
            }
        }


        public abstract void OnKeyReleased();

        public virtual void OnKeyPressed() {
        }

    }
}