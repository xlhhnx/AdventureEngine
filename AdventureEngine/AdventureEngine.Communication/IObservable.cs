﻿namespace AdventureEngine.Communication
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        bool Observing(IObserver observer);
    }
}