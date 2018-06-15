using System;
using System.Collections.Generic;
using AdventureEngine.UserInterface.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace AdventureEngine.UserInterface.Controls
{
    public abstract class BaseTextBox : ITextBox
    {
        public virtual IBounds Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public virtual bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public virtual bool Focused { get { return _focused; } }

        public virtual Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public virtual IScreen Screen
        {
            get { return _screen; }
            set { _screen = value; }
        }

        public virtual int TabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; }
        }

        public virtual bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public virtual int Cursor
        {
            get { return _cursor; }
            protected set
            {
                _cursor = Utility.Clamp(value, 0, FullText.Length - 1);
            }
        }

        public virtual bool Clicked { get { return _clicked; } }
        public virtual bool Capslock { get { return _capslock; } }
        public virtual bool Numlock { get { return _numlock; } }
        public virtual bool Selected { get { return _selected; } }

        public virtual string FullText
        {
            get { return _fullText; }
            set { _fullText = value; }
        }

        public abstract string DisplayText { get; }
        public abstract Vector2 TextDimensions { get; }
        public abstract Vector2 DisplayDimensions { get; }

        protected bool _visible;
        protected bool _enabled;
        protected bool _focused;
        public bool _clicked;
        protected bool _selected;
        protected bool _mouseInBounds;
        protected bool _capslock;
        protected bool _numlock;
        protected int _tabIndex;
        protected int _cursor;
        protected int _shiftStart;
        protected int _shiftEnd;
        protected int _keyDownPauseTime;
        protected string _fullText;
        protected IBounds _bounds;
        protected IScreen _screen;
        protected Vector2 _position;
        protected Dictionary<Keys, TimeSpan> _keyDownTimes;


        public BaseTextBox(int tabIndex, int keyDownPauseTime, IBounds bounds, IScreen screen, Vector2 position, string fullText = "", bool visible = true, bool enabled = true, bool focused = false)
        {
            _visible = visible;
            _enabled = enabled;
            _focused = focused;
            _tabIndex = tabIndex;
            _fullText = fullText;
            _keyDownPauseTime = keyDownPauseTime;
            _bounds = bounds;
            _screen = screen;
            _position = position;
            
            _shiftStart = -1;
            _shiftEnd = -1;
            _keyDownTimes = new Dictionary<Keys, TimeSpan>();
        }

        public virtual void Focus()
        {
            _focused = true;
        }

        public virtual void Unfocus()
        {
            _focused = false;
        }

        public virtual void Insert(char letter)
        {
            FullText = FullText.Substring(0,Cursor) + letter + FullText.Substring(Cursor + 1, FullText.Length - 1);
            Cursor++;
        }

        public virtual void Paste(string substring)
        {
            if (_shiftStart > -1 && _shiftEnd > -1)
            {
                if (_shiftStart < _shiftEnd)
                {
                    Cursor = _shiftStart;
                    FullText.Remove(_shiftStart, _shiftEnd - _shiftStart);
                    FullText = FullText.Substring(0, Cursor) + substring + FullText.Substring(Cursor + 1, FullText.Length - 1);
                    Cursor += substring.Length;
                }
                else
                {
                    Cursor = _shiftEnd;
                    FullText.Remove(_shiftEnd, _shiftStart - _shiftEnd);
                    FullText = FullText.Substring(0, Cursor) + substring + FullText.Substring(Cursor + 1, FullText.Length - 1);
                    Cursor += substring.Length;
                }
            }
            else
            {
                FullText = FullText.Substring(0, Cursor) + substring + FullText.Substring(Cursor + 1, FullText.Length - 1);
                Cursor += substring.Length;
            }
        }

        public virtual void Remove()
        {
            if (_shiftStart > -1 && _shiftEnd > -1)
            {
                if (_shiftStart < _shiftEnd)
                {
                    Cursor = _shiftStart;
                    FullText.Remove(_shiftStart, _shiftEnd - _shiftStart);
                }
                else
                {
                    Cursor = _shiftEnd;
                    FullText.Remove(_shiftEnd, _shiftStart - _shiftEnd);
                }
            }
            _shiftStart = -1;
            _shiftEnd = -1;
        }

        public virtual void Delete()
        {
            FullText = FullText.Remove(Cursor + 1, 1);
        }

        public virtual void Backspace()
        {
            FullText = FullText.Remove(Cursor,1);
        }

        public virtual void Select()
        {
            _selected = true;
        }

        public virtual void Deselect()
        {
            _selected = false;
        }

        public virtual void ReceiveMessage(Message message)
        {
            if (message is MouseButtonStatesMessage) HandleMouseButtonStateMessage(message as MouseButtonStatesMessage);
            else if (message is MouseMoveMessage) HandleMouseMoveState(message as MouseMoveMessage);
            else if (message is KeyboardStateMessage) HandleKeyboardStateMessage(message as KeyboardStateMessage);
        }

        // TODO: HandleKeyboardStateMessage needs refactoring
        protected virtual void HandleKeyboardStateMessage(KeyboardStateMessage keyboardStateMessage)
        {
            if (!_selected) return;
            var shift = keyboardStateMessage.KeyStates[Keys.RightShift] == ButtonState.Down || keyboardStateMessage.KeyStates[Keys.LeftShift] == ButtonState.Down;

            foreach (var k in keyboardStateMessage.PressedKeys)
            {
                _keyDownTimes.Add(k, new TimeSpan());

                if (Utility.IsText(k))
                {
                    if (shift || _capslock) Insert(k.ToString().ToUpper()[0]);
                    else Insert(k.ToString().ToLower()[0]);
                }
                else if (Utility.IsNumPad(k))
                {
                    if (_numlock) Insert(k.ToString()[0]);
                    else
                    {
                        if (k == Keys.NumPad6 || k == Keys.Right)
                        {
                            if (shift)
                            {
                                if (_shiftStart < 0) _shiftStart = Cursor;
                                _shiftEnd = Cursor + 1;
                            }
                            Cursor++;
                        }
                        else if (k == Keys.NumPad4 || k == Keys.Left)
                        {
                            if (shift)
                            {
                                if (_shiftStart < 0) _shiftStart = Cursor;
                                _shiftEnd = Cursor - 1;
                            }
                            Cursor--;
                        }
                    }
                }
                else if (k == Keys.Home)
                {
                    if (shift)
                    {
                        if (_shiftStart < 0) _shiftStart = Cursor;
                        _shiftEnd = 0;
                    }
                    Cursor = 0;
                }
                else if (k == Keys.End)
                {
                    if (shift)
                    {
                        if (_shiftStart < 0) _shiftStart = Cursor;
                        _shiftEnd = FullText.Length - 1;
                    }
                    Cursor = FullText.Length - 1;
                }
                else if (k == Keys.Back)
                {
                    if (_shiftStart > -1 && _shiftEnd > -1) Remove();
                    else Backspace();
                }
                else if (k == Keys.Delete)
                {
                    if (_shiftStart > -1 && _shiftEnd > -1) Remove();
                    else Delete();
                }
                else if (k == Keys.Escape) Unfocus();
                else if (k == Keys.NumLock) _numlock = !_numlock;
                else if (k == Keys.CapsLock) _capslock = !Capslock;
            }

            foreach (var k in keyboardStateMessage.ReleasedKeys)
            {
                if (_keyDownTimes.ContainsKey(k)) _keyDownTimes.Remove(k);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            if (!_selected)
            {
                _keyDownTimes = new Dictionary<Keys, TimeSpan>();
                return;
            }

            var shift = _keyDownTimes.ContainsKey(Keys.LeftShift) || _keyDownTimes.ContainsKey(Keys.RightShift);

            foreach (var k in _keyDownTimes.Keys)
            {
                _keyDownTimes[k] += gameTime.ElapsedGameTime;
                if (_keyDownTimes[k].TotalMilliseconds > _keyDownPauseTime)
                {
                    if (Utility.IsText(k))
                    {
                        if (shift) Insert(k.ToString().ToUpper()[0]);
                        else Insert(k.ToString().ToLower()[0]);
                    }
                    else if (Utility.IsNumPad(k))
                    {
                        if (_numlock == true) Insert(k.ToString()[0]);
                        else
                        {
                            if (k == Keys.NumPad6 || k == Keys.Right)
                            {
                                if (shift)
                                {
                                    if (_shiftStart < 0) _shiftStart = Cursor;
                                    _shiftEnd = Cursor + 1;
                                }
                                Cursor++;
                            }
                            else if (k == Keys.NumPad4 || k == Keys.Left)
                            {
                                if (shift)
                                {
                                    if (_shiftStart < 0) _shiftStart = Cursor;
                                    _shiftEnd = Cursor - 1;
                                }
                                Cursor--;
                            }
                        }
                    }
                    else if (k == Keys.Home)
                    {
                        if (shift)
                        {
                            if (_shiftStart < 0) _shiftStart = Cursor;
                            _shiftEnd = 0;
                        }
                        Cursor = 0;
                    }
                    else if (k == Keys.End)
                    {
                        if (shift)
                        {
                            if (_shiftStart < 0) _shiftStart = Cursor;
                            _shiftEnd = FullText.Length - 1;
                        }
                        Cursor = FullText.Length - 1;
                    }
                    else if (k == Keys.Back)
                    {
                        if (_shiftStart > -1 && _shiftEnd > -1) Remove();
                        else Backspace();
                    }
                    else if (k == Keys.Delete)
                    {
                        if (_shiftStart > -1 && _shiftEnd > -1) Remove();
                        else Delete();
                    }
                }
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        protected virtual void HandleMouseButtonStateMessage(MouseButtonStatesMessage message)
        {
            if (!_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Pressed) _clicked = true;
            else if (_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Released)
            {
                _clicked = false;
                _shiftStart = -1;
                _shiftEnd = -1;
                Select();
            }
            else if (_clicked && !_mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Released)
            {
                _clicked = false;
                _shiftStart = -1;
                _shiftEnd = -1;
                Deselect();
            }
        }

        protected virtual void HandleMouseMoveState(MouseMoveMessage message)
        {
            if (_bounds.Contains(message.Position))
            {
                _focused = true;
                _mouseInBounds = true;
            }
            else
            {
                _focused = false;
                _mouseInBounds = false;
            }
        }

        public virtual string Copy()
        {
            if (_shiftStart > -1 && _shiftEnd > -1)
            {
                if (_shiftStart < _shiftEnd) return FullText.Substring(_shiftStart, _shiftEnd - _shiftStart);
                else return FullText.Substring(_shiftEnd, _shiftStart - _shiftEnd);
            }
            else return FullText;
        }

        public virtual string Copy(int startIndex, int endIndex)
        {
            if (startIndex > -1 && endIndex > -1)
            {
                if (startIndex < endIndex) return FullText.Substring(startIndex, endIndex - startIndex);
                else return FullText.Substring(endIndex, startIndex - endIndex);
            }
            else if (_shiftStart > -1 && _shiftEnd > -1)
            {
                if (_shiftStart < _shiftEnd) return FullText.Substring(_shiftStart, _shiftEnd - _shiftStart);
                else return FullText.Substring(_shiftEnd, _shiftStart - _shiftEnd);
            }
            else return FullText;
        }
    }
}