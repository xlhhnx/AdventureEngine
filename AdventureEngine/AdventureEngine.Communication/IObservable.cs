public interface IObservable
{
    void Subscribe(Observer observer);
    void Unsubscribe(Observer observer);
    bool Observing(Observer observer);
}