using AdventureEngine.UserInterface.Screens;

namespace AdventureEngine.UserInterface.Controls
{
    public interface IControl : IUserInterfaceObject, ISubscriber
    {
        bool Focused { get; }
        int TabIndex { get; set; }
        IScreen Screen { get; set; }
        IBounds Bounds { get; set; }
    }
}