public class MessagingKeyboardController : KeyboardController
{
    /// <summary>
    /// Updates the keyboard controller with the current keyboard state and sends a message if the state has changed.
    /// </summary>
    public override void Update()
    {
        base.Update();

        if (_stateChanged)
        {
            var message = new KeyboardStateMessage(_keyStates, this);
            MessageManager.EnqueueMessage(message);
        }
    }
}