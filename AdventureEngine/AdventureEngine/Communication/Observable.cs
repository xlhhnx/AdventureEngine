public interface Observable
{
    void Subscribe(Observer observer);
    void Unsubscribe(Observer observer);
    bool Observing(Observer observer);
}