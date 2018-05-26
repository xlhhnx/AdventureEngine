using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

public class KeyboardController : IController
{
    /// <summary>
    /// Gets the flg determining if the state has changed since the last update.
    /// </summary>
    public bool StateChanged { get { return _stateChanged; } }

    /// <summary>
    /// Gets a list of all keys.
    /// </summary>
    public List<Keys> AllKeys { get { return _allKeys; } }

    /// <summary>
    /// Accesses the button state of the key provided.
    /// </summary>
    /// <param name="key">The key to access.</param>
    /// <returns>A button state or null.</returns>
    public ButtonState? this[Keys key]
    {
        get
        {
            if (_keyStates.ContainsKey(key))
            {
                return _keyStates[key];
            }
            else
            {
                return null;
            }
        }
    }

    protected bool _stateChanged;
    protected KeyboardState _previousKeyboardState;
    protected Dictionary<Keys, ButtonState> _keyStates;
    protected List<Keys> _allKeys;

    /// <summary>
    /// Creates a keybard controller.
    /// </summary>
    public KeyboardController()
    {
        _previousKeyboardState = new KeyboardState();
        _keyStates = new Dictionary<Keys, ButtonState>();
        _allKeys = new List<Keys>();

        foreach (Keys k in Enum.GetValues(typeof(Keys)).Cast<Keys>())
        {
            _keyStates.Add(k, ButtonState.Up);
            _allKeys.Add(k);
        }
        _stateChanged = false;
    }

    /// <summary>
    /// Updates the keyboard controller with the current keyboard state.
    /// </summary>
    public virtual void Update()
    {
        var _currentKeyboardState = Keyboard.GetState();
        _stateChanged = false;

        foreach (Keys k in _allKeys)
        {
            switch (_keyStates[k]) {
                case (ButtonState.Up):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                        {
                            _keyStates[k] = ButtonState.Pressed;
                            _stateChanged = true;
                        }
                        else
                        {
                            _keyStates[k] = ButtonState.Up;
                        }
                    }break;
                case (ButtonState.Pressed):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                        {
                            _keyStates[k] = ButtonState.Down;
                            _stateChanged = true;
                        }
                        else
                        {
                            _keyStates[k] = ButtonState.Released;
                            _stateChanged = true;
                        }
                    }
                    break;
                case (ButtonState.Down):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                        {
                            _keyStates[k] = ButtonState.Down;
                        }
                        else
                        {
                            _keyStates[k] = ButtonState.Released;
                            _stateChanged = true;
                        }
                    }
                    break;
                case (ButtonState.Released):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                        {
                            _keyStates[k] = ButtonState.Pressed;
                            _stateChanged = true;
                        }
                        else
                        {
                            _keyStates[k] = ButtonState.Up;
                            _stateChanged = true;
                        }
                    }
                    break;
            }
        }
        _previousKeyboardState = _currentKeyboardState;
    }
}