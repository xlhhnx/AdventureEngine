using AdventureEngine.Messaging;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureEngine.Input.Messages
{
    public class KeyboardStateMessage : Message, ButtonsMessage<Keys>
    {
        public Dictionary<Keys, ButtonState> KeyStates { get { return _keyStates; } }

        public List<Keys> DownKeys
        {
            get
            {
                if (_downKeys == null)
                {
                    _downKeys = _keyStates.Keys.Where(k => _keyStates[k] == ButtonState.Down)
                                        .ToList();
                }
                return _downKeys;
            }
        }

        public List<Keys> PressedKeys
        {
            get
            {
                if (_pressedKeys == null)
                {
                    _pressedKeys = _keyStates.Keys.Where(k => _keyStates[k] == ButtonState.Pressed)
                                        .ToList();
                }
                return _pressedKeys;
            }
        }

        public List<Keys> UpKeys
        {
            get
            {
                if (_upKeys == null)
                {
                    _upKeys = _keyStates.Keys.Where(k => _keyStates[k] == ButtonState.Up)
                                        .ToList();
                }
                return _upKeys;
            }
        }

        public List<Keys> ReleasedKeys
        {
            get
            {
                if (_releasedKeys == null)
                {
                    _releasedKeys = _keyStates.Keys.Where(k => _keyStates[k] == ButtonState.Released)
                                        .ToList();
                }
                return _releasedKeys;
            }
        }

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
        protected List<Keys> _downKeys;
        protected List<Keys> _pressedKeys;
        protected List<Keys> _upKeys;
        protected List<Keys> _releasedKeys;


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
            if (!equal)
                return equal;

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
}