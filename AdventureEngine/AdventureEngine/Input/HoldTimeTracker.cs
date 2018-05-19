using Microsoft.Xna.Framework;
using System;

/// <summary>
/// Tracks the hold time of a single button. Uses a message to determine the ButtonState.
/// </summary>
/// <typeparam name="T">The type of the identifier used to look up the ButtonState on the message.</typeparam>
public class HoldTimeTracker<T>
{
    /// <summary>
    /// Gets the bolloean value determining whether the button is being held.
    /// </summary>
    public bool Held { get { return _held; } }

    protected TimeSpan _elapsedTime;
    protected ButtonsMessage<T> _lastMessage;
    protected T _button;
    protected bool _held;
    protected int _holdTimeMilliseconds;

    /// <summary>
    /// Builds a HOLD_TIME_TRACKER.
    /// </summary>
    /// <param name="button">The button identifier that that identifies the button be tracked</param>
    /// <param name="holdTimeMilliseconds"></param>
    public HoldTimeTracker(T button, int holdTimeMilliseconds)
    {
        _button = button;
        _holdTimeMilliseconds = holdTimeMilliseconds;

        _elapsedTime = new TimeSpan();
    }

    /// <summary>
    /// Updates the elspased time and sets the held parameter to true if the elapsed time exceeds the designated hold time.
    /// </summary>
    /// <param name="gameTime">The standard gameTime passed to all update methods.</param>
    public void Update(GameTime gameTime)
    {
        if (_lastMessage[_button] == ButtonState.Down)
        {
            _elapsedTime += gameTime.ElapsedGameTime;

            if (_elapsedTime.TotalMilliseconds > _holdTimeMilliseconds)
            {
                _held = true;
            }
        }
    }

    /// <summary>
    /// Uses the message provided to determine if the elapsed time and held parameters need to be reset.
    /// </summary>
    /// <param name="message"></param>
    public void HandleMessage(ButtonsMessage<T> message)
    {
        _lastMessage = message;
        if (_lastMessage[_button] != ButtonState.Down)
        {
            _elapsedTime = new TimeSpan();
            _held = false;
        }
    }
}