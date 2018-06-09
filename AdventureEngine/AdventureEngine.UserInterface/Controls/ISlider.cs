public interface ISlider : IControl
{
    float Max { get; set; }
    float Min { get; set; }
    float Step { get; set; }
    float Value { get; set; }

    void Increment();
    void Decrement();
}