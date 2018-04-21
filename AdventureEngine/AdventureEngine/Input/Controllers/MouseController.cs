using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

public class MouseController : InputController
{
    // Properties

    // Variables
    protected MouseState _previousMouseState;
    protected Dictionary<string, ButtonState> _buttonStates;

    // Methods
    public MouseController()
    {
        _previousMouseState = new MouseState();
        _buttonStates = new Dictionary<string, ButtonState>();

    }

    public void Update(GameTime gameTime)
    {
        MouseState _currentMouseState = Mouse.GetState();
        var _previousButtonStates = GetButtonStates(_currentMouseState);

        // Handle mouse location
        if (_previousMouseState.Position != _currentMouseState.Position)
            MessageQueue.EnqueueMessage(new MouseMoveMessage(_currentMouseState.Position, this));

        // Handle mouse buttons
        foreach (string button in _previousButtonStates.Keys)
        {
            switch (_buttonStates[button]) {
                case (ButtonState.Up):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                            _buttonStates[button] = ButtonState.Pressed;
                        else
                            _buttonStates[button] = ButtonState.Up;
                    }
                    break;
                case (ButtonState.Pressed):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                            _buttonStates[button] = ButtonState.Down;
                        else
                            _buttonStates[button] = ButtonState.Released;
                    }
                    break;
                case (ButtonState.Down):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                            _buttonStates[button] = ButtonState.Down;
                        else
                            _buttonStates[button] = ButtonState.Released;
                    }
                    break;
                case (ButtonState.Released):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                            _buttonStates[button] = ButtonState.Pressed;
                        else
                            _buttonStates[button] = ButtonState.Up;
                    }
                    break;
            }
        }
        MessageQueue.EnqueueMessage(new MouseButtonStatesMessage(_buttonStates, this));

        // Handle mouse scroll wheel
        if (_previousMouseState.ScrollWheelValue != _currentMouseState.ScrollWheelValue)
            MessageQueue.EnqueueMessage(new MouseScrollWheelChangedMessage(_currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue, this));

        _previousMouseState = _currentMouseState;
    }

    private Dictionary<string, Microsoft.Xna.Framework.Input.ButtonState> GetButtonStates(MouseState mouseState)
    {
        Dictionary<string, Microsoft.Xna.Framework.Input.ButtonState> _buttonStates = new Dictionary<string, Microsoft.Xna.Framework.Input.ButtonState>();

        _buttonStates.Add("LeftButton", mouseState.LeftButton);
        _buttonStates.Add("MiddleButton", mouseState.MiddleButton);
        _buttonStates.Add("RightButton", mouseState.RightButton);
        _buttonStates.Add("ExtraButton1", mouseState.XButton1);
        _buttonStates.Add("ExtraButton2", mouseState.XButton2);

        return _buttonStates;
    }
}