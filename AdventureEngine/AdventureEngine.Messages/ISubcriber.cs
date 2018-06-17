namespace AdventureEngine.Messaging
{
    public interface ISubscriber
    {
        void ReceiveMessage(Message message);
    }
}