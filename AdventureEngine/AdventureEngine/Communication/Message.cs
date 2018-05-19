using System;

public abstract class Message
{
    // Properties
    public int LogLevel { get { return _logLevel; } }
    public string Type { get { return _type; } }
    public object Sender { get { return _sender; } }

    public TimeSpan ExecutionTime
    {
        get { return _executionTime; }
        set { _executionTime = value; }
    }

    // Variables
    protected int _logLevel;
    protected string _type;
    protected object _sender;
    protected TimeSpan _executionTime;

    // Methods
    public Message(string type, object sender)
    {
        _type = type;
        _sender = sender;
        _logLevel = 4;
    }

    public override int GetHashCode()
    {
        return Type.GetHashCode() + Sender.GetHashCode();
    }
}