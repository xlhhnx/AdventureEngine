public interface IMenuOption : IControl
{
    int Index { get; set; }

    void Select();
}