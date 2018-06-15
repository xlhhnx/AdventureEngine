using Microsoft.Xna.Framework;

namespace AdventureEngine.UserInterface.Controls
{
    public interface ILabel : IControl
    {
        string DisplayText { get; }
        string FullText { get; set; }
        Color TextColor { get; set; }
        Color DisbaledColor { get; set; }
    }
}