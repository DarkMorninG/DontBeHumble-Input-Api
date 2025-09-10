namespace DBH.Input.api.Extending {
    public abstract class AbstractInputSystem {
        private bool enabled;

        public bool Enabled {
            get => enabled;
            set => enabled = value;
        }

        public abstract string MappedName();
    }
}