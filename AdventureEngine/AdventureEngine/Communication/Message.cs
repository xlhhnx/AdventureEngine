using System;

public abstract class Message
{
    // Properties
    public string Type
    {
        get { return _type; }
    }

    public object Sender
    {
        get {  return _sender; }
    }

    public TimeSpan ExecutionTime
    {
        get { return _executionTime; }
        set { _executionTime = value; }
    }

    // Variables
    protected string _type;
    protected object _sender;
    protected TimeSpan _executionTime;

    // MEthods
    public Message(string type, object sender)
    {
        _type = type;
        _sender = sender;
    }
}