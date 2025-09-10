using DBH.Input.api.Keys;

namespace DBH.Input.api.Extending {
    public interface IInputController {
        void DisableGroup(string group);
        void EnableGroup(string group);
        void AddButton(InputKeys keys);
        void AddButton(DirectionKeys keys);
    }
}