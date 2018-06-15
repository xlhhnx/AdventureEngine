namespace AdventureEngine.UserInterface.Controls
{
    public interface IButton : IControl
    {
        bool Clicked { get; }

        void Select();
    }
}