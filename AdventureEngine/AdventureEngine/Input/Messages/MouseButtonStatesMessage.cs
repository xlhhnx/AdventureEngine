using System.Collections.Generic;

public class MouseButtonStatesMessage : Message
{
    // Properties
    public Dictionary<string, ButtonState> ButtonState
    {
        get { return _buttonStates; }
    }

    // Variables
    protected Dictionary<string, ButtonState> _buttonStates;

    // Method
    public MouseButtonStatesMessage(Dictionary<string, ButtonState> buttonStates, object sender) : base("MOUSE_BUTTON_STATES", sender)
    {
        _buttonStates = buttonStates;
    }
}