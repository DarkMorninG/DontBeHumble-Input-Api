namespace DBH.Input.api.Extending {
    public interface IDirectionInputSystem {
        void FixedUpdate();
        
        string MappedName();
        
        bool Enabled { get; set; }
    }
}