using System.Collections.Generic;

public class MouseButtonStatesMessage : Message, ButtonsMessage<string>
{
    /// <summary>
    /// Get the dictionary of ButtonNames => ButtonStates.
    /// </summary>
    public Dictionary<string, ButtonState> ButtonState { get { return _buttonStates; } }

    /// <summary>
    /// Indexer of ButtonName => ButtonState.
    /// </summary>
    /// <param name="button">The name of the button used to look up ButtonState.</param>
    /// <returns>ButtonState if found, otherwise null.</returns>
    public ButtonState? this[string button]
    {
        get
        {
            if (_buttonStates.ContainsKey(button))
            {
                return _buttonStates[button];
            }
            else
            {
                return null;
            }
        }
    }

    protected Dictionary<string, ButtonState> _buttonStates;

    /// <summary>
    /// Builds a MOUSE_BUTTON_STATES message.
    /// </summary>
    /// <param name="buttonStates">The dictionary of ButtonNames => ButtonStates.</param>
    /// <param name="sender">The object that created the message.</param>
    public MouseButtonStatesMessage(Dictionary<string, ButtonState> buttonStates, object sender) : base("MOUSE_BUTTON_STATES", sender)
    {
        _buttonStates = buttonStates;
    }

    public override bool Equals(object obj)
    {
        var equals = obj is MouseButtonStatesMessage;
        var mObj = obj as MouseButtonStatesMessage;

        // Short circuit if object is not  MouseButtonStatesMessage
        if (!equals) return equals;

        foreach (string button in _buttonStates.Keys)
        {
            if (!mObj.ButtonState.ContainsKey(button) || mObj.ButtonState[button] != _buttonStates[button])
            {
                equals = false;
                break;
            }
        }

        return equals;
    }

    public override string ToString()
    {
        string output = $"{_type} : [";

        foreach (string button in _buttonStates.Keys)
        {
            output += $"({button},{_buttonStates[button]})";
        }

        output += "]";
        return output;
    }
}