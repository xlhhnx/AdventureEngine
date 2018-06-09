public interface IControl : IUserInterfaceObject, ISubscriber
{
    bool Focused { get; }
    int TabIndex { get; }
    IScreen Screen { get; set; }
    IBounds Bounds { get; set; }
}