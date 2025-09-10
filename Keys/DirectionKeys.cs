using System;
using UnityEngine;

namespace DBH.Input.api.Keys {
    [Serializable]
    public class DirectionKeys {
        [SerializeField]
        private string group;

        [SerializeField]
        private string name;

        public string Name {
            get => name;
            set => name = value;
        }

        public string Group {
            get => group;
            set => group = value;
        }

        public DirectionKeys(string group, string name) {
            this.name = name;
            this.group = group;
        }
    }
}