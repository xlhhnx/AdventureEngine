using Microsoft.Xna.Framework;

namespace AdventureEngine.UserInterface.Controls
{
    public interface ISlider : IControl
    {
        bool Clicked { get; }
        int StepCount { get; }
        float Max { get; set; }
        float Min { get; set; }
        float StepSize { get; set; }
        float Value { get; set; }
        Vector2 Dimensions { get; set; }

        void Increment();
        void Decrement();
    }
}