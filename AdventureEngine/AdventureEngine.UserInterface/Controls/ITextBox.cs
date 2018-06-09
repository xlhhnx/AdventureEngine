using Microsoft.Xna.Framework;

public interface ITextBox : IControl
{
    string FullText { get; set; }
    string DisplayText { get; }
    Vector2 TextDimensions { get; }
    Vector2 DisplayDimensions { get; }
}