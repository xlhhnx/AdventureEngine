namespace AdventureEngine.UserInterface.Controls
{
    public interface IRadioButton : IControl
    {
        bool Clicked { get; }
        bool Selected { get; }
        IRadioButtonCollection RadioButtonCollection { get; set; }

        void Select();
        void Deselect();
    }
}