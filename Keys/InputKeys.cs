using System;
using System.Collections.Generic;
using UnityEngine;

namespace DBH.Input.api.Keys {
    [Serializable]
    public class InputKeys {
        [SerializeField]
        private string group;

        [SerializeField]
        private string name;

        [SerializeField]
        private List<KeyCode> input;

        public string Group {
            get => group;
            set => group = value;
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public List<KeyCode> Input {
            get => input;
            set => input = value;
        }

        public InputKeys(string group, string name, List<KeyCode> input) {
            this.group = group;
            this.name = name;
            this.input = input;
        }
    }
}