using Microsoft.Xna.Framework;

namespace AdventureEngine.UserInterface.Controls
{
    public interface ITextBox : IControl
    {
        bool Selected { get; }
        bool Clicked { get; }
        bool Capslock { get; }
        bool Numlock { get; }
        int Cursor { get; }
        string FullText { get; set; }
        string DisplayText { get; }
        Vector2 TextDimensions { get; }
        Vector2 DisplayDimensions { get; }

        void Select();
        void Deselect();
        void Delete();
        void Backspace();
        void Insert(char letter);
        void Paste(string substring);
        void Remove();
        string Copy();
        string Copy(int startIndex, int endIndex);
    }
}