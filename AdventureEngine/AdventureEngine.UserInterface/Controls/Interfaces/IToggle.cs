namespace AdventureEngine.UserInterface.Controls
{
    public interface IToggle : IControl
    {
        bool Clicked { get; }
        bool Checked { get; }

        void Toggle();
    }
}