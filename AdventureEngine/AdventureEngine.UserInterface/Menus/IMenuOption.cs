using AdventureEngine.UserInterface.Controls;

namespace AdventureEngine.UserInterface.Menus
{
    public interface IMenuOption : IControl
    {
        int Index { get; set; }

        void Select();
    }
}