using AdventureEngine.Input.Messages;
using AdventureEngine.Messaging;

namespace AdventureEngine.Input.Controllers
{
    public class MessagingMouseController : MouseController
    {
        public override void Update()
        {
            base.Update();

            if (_positionStateChanged)
            {
                var message = new MouseMoveMessage(_previousMouseState.Position, this);
                MessageManager.EnqueueMessage(message);
            }

            if (_buttonsStateChanged)
            {
                var message = new MouseButtonStatesMessage(_buttonStates, this);
                MessageManager.EnqueueMessage(message);
            }

            if (_scrollWheelValueChanged)
            {
                var message = new MouseScrollWheelChangedMessage(_scrollWheelDifference, this);
                MessageManager.EnqueueMessage(message);
            }
        }
    }
}