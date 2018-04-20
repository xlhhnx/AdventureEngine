using System;

public abstract class Observer : IDisposable
{
    // Properties

    // Variables
    protected Observable _observable;

    // Methods
    public void Dispose()
    {
        if(_observable != null && _observable.Observing(this))
            _observable.Unsubscribe(this);
    }
}