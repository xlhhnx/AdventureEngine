using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

public class KeyboardStateMessage : Message, ButtonsMessage<Keys>
{
    /// <summary>
    /// Gets the dictionary of Keys => Key ButtonStates.
    /// </summary>
    public Dictionary<Keys, ButtonState> KeyStates { get { return _keyStates; } }

    /// <summary>
    /// Indexer of Keys => Key ButtonState.
    /// </summary>
    /// <param name="k">Key used to lookup Key ButtonState</param>
    /// <returns>ButtonState if found, otherwise null.</returns>
    public ButtonState? this[Keys k]
    {
        get
        {
            if (_keyStates.ContainsKey(k))
            {
                return _keyStates[k];
            }
            else
            {
                return null;
            }
        }
    }

    protected Dictionary<Keys, ButtonState> _keyStates;

    /// <summary>
    /// Builds a KEYBOARD_KEY_STATES message.
    /// </summary>
    /// <param name="keyStates">The dictionary of Keys => Key ButtonStates.</param>
    /// <param name="sender">The object that created the message.</param>
    public KeyboardStateMessage(Dictionary<Keys, ButtonState> keyStates, object sender) : base("KEYBOARD_KEY_STATES", sender)
    {
        _keyStates = keyStates;
        // _logLevel = 3;
    }

    public override bool Equals(object obj)
    {
        var equal = obj is KeyboardStateMessage;
        var mObj = obj as KeyboardStateMessage;

        // Short circuit if object is not a KeyboardStateMessage
        if (!equal) return equal;

        foreach (Keys key in _keyStates.Keys)
        {
            if (!mObj.KeyStates.ContainsKey(key) || mObj.KeyStates[key] != _keyStates[key])
            {
                equal = false;
                break;
            }
        }

        return equal;
    }

    public override string ToString()
    {
        var output = $"{_type} [";

        foreach (Keys key in _keyStates.Keys)
        {
            output += $"({key},{_keyStates[key]})";
        }

        output += "]";
        return output;
    }
}