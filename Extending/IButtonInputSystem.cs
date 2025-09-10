namespace DBH.Input.api.Extending {
    public interface IButtonInputSystem {
        string MappedName();
        void KeyReleased();
        void KeyPressed();
        bool Enabled { get; set; }
    }
}