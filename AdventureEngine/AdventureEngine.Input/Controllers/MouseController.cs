using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

public class MouseController : IController
{
    /// <summary>
    /// Gets the most recent mouse location.
    /// </summary>
    public Vector2 MouseLocation { get { return _previousMouseState.Position.ToVector2(); } }

    /// <summary>
    /// Gets the mose recent mouse wheel value.
    /// </summary>
    public int MouseWheelValue { get { return _previousMouseState.ScrollWheelValue; } }
    
    /// <summary>
    /// Gets the list of button names.
    /// </summary>
    public List<string> ButtonNames { get { return new List<string>(_buttonStates.Keys); } }

    /// <summary>
    /// Accesses the button state of the button name provided.
    /// </summary>
    /// <param name="buttonName">The name of the button to access.</param>
    /// <returns>A button state or null.</returns>
    public ButtonState? this[string buttonName]
    {
        get
        {
            if (_buttonStates.ContainsKey(buttonName))
            {
                return _buttonStates[buttonName];
            }
            else
            {
                return null;
            }
        }
    }

    protected bool _buttonsStateChanged;
    protected bool _positionStateChanged;
    protected bool _scrollWheelValueChanged;
    protected int _scrollWheelDifference;
    protected MouseState _previousMouseState;
    protected Dictionary<string, ButtonState> _buttonStates;

    /// <summary>
    /// Creates a mouse controller.
    /// </summary>
    public MouseController()
    {
        _previousMouseState = new MouseState();
        _buttonStates = new Dictionary<string, ButtonState>()
        {
            { "LeftButton", ButtonState.Up },
            { "MiddleButton", ButtonState.Up },
            { "RightButton", ButtonState.Up },
            { "ExtraButton1", ButtonState.Up },
            { "ExtraButton2", ButtonState.Up }
        };
        _buttonsStateChanged = false;
        _positionStateChanged = false;
        _scrollWheelValueChanged = false;
    }

    /// <summary>
    /// Updates the mouse controller with th current mouse state.
    /// </summary>
    public virtual void Update()
    {
        _buttonsStateChanged = false;
        _positionStateChanged = false;
        _scrollWheelValueChanged = false;
        MouseState _currentMouseState = Mouse.GetState();
        var _previousButtonStates = GetButtonStates(_currentMouseState);

        // Handle mouse buttons
        foreach (string button in _previousButtonStates.Keys)
        {
            switch (_buttonStates[button]) {
                case (ButtonState.Up):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                        {
                            _buttonStates[button] = ButtonState.Pressed;
                            _buttonsStateChanged = true;
                        }
                        else
                        {
                            _buttonStates[button] = ButtonState.Up;
                        }
                    }
                    break;
                case (ButtonState.Pressed):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                        {
                            _buttonStates[button] = ButtonState.Down;
                            _buttonsStateChanged = true;
                        }
                        else
                        {
                            _buttonStates[button] = ButtonState.Released;
                            _buttonsStateChanged = true;
                        }
                    }
                    break;
                case (ButtonState.Down):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                        {
                            _buttonStates[button] = ButtonState.Down;
                        }
                        else
                        {
                            _buttonStates[button] = ButtonState.Released;
                            _buttonsStateChanged = true;
                        }
                    }
                    break;
                case (ButtonState.Released):
                    {
                        if (_previousButtonStates[button] == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                        {
                            _buttonStates[button] = ButtonState.Pressed;
                            _buttonsStateChanged = true;
                        }
                        else
                        {
                            _buttonStates[button] = ButtonState.Up;
                            _buttonsStateChanged = true;
                        }
                    }
                    break;
            }
        }

        if (_currentMouseState.Position != _previousMouseState.Position)
        {
            _positionStateChanged = true;
        }

        if (_currentMouseState.ScrollWheelValue != _previousMouseState.ScrollWheelValue)
        {
            _scrollWheelDifference = _currentMouseState.ScrollWheelValue - _previousMouseState.ScrollWheelValue;
            _scrollWheelValueChanged = true;
        }

        _previousMouseState = _currentMouseState;
    }

    /// <summary>
    /// Gets the states of the mouse buttons.
    /// </summary>
    /// <param name="mouseState">The mouse state to check.</param>
    /// <returns>A dictionary of button names => button states.</returns>
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