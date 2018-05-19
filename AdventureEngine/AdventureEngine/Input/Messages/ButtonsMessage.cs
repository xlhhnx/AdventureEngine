public interface ButtonsMessage<T>
{
    ButtonState? this[T button] { get; }
}