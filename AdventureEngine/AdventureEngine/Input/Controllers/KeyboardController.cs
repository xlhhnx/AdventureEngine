﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

public class KeyboardController : InputController
{
    // Properties

    // Variables
    protected KeyboardState _previousKeyboardState;
    protected Dictionary<Keys, ButtonState> _keyStates;

    // Methods
    public KeyboardController()
    {
        _previousKeyboardState = new KeyboardState();
        _keyStates = new Dictionary<Keys, ButtonState>();

        foreach (Keys k in Enum.GetValues(typeof(Keys)).Cast<Keys>())
            _keyStates.Add(k, ButtonState.Up);
    }

    public void Update(GameTime gameTime)
    {
        KeyboardState _currentKeyboardState = Keyboard.GetState();

        foreach (Keys k in _keyStates.Keys)
        {
            switch (_keyStates[k]) {
                case (ButtonState.Up):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                            _keyStates[k] = ButtonState.Pressed;
                        else
                            _keyStates[k] = ButtonState.Up;
                    }break;
                case (ButtonState.Pressed):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                            _keyStates[k] = ButtonState.Down;
                        else
                            _keyStates[k] = ButtonState.Released;
                    }
                    break;
                case (ButtonState.Down):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                            _keyStates[k] = ButtonState.Down;
                        else
                            _keyStates[k] = ButtonState.Released;
                    }
                    break;
                case (ButtonState.Released):
                    {
                        if (_currentKeyboardState.IsKeyDown(k))
                            _keyStates[k] = ButtonState.Pressed;
                        else
                            _keyStates[k] = ButtonState.Up;
                    }
                    break;
            }
        }

        // TODO: Enqueue KeyboardStateMessage

        _previousKeyboardState = _currentKeyboardState;
    }
}