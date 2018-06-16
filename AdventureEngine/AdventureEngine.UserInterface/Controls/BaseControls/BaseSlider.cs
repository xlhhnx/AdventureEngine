using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AdventureEngine.UserInterface.Screens;
using AdventureEngine.Input.Messages;
using AdventureEngine.Messaging;
using AdventureEngine.Input;
using AdventureEngine.Common.Bounding;
using AdventureEngine.Common;

namespace AdventureEngine.UserInterface.Controls
{
    public abstract class BaseSlider : ISlider
    {
        public virtual bool Clicked { get { return _clicked; } }
        public virtual bool Focused { get { return _focused; } }

        public virtual bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public virtual bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public virtual int TabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; }
        }

        public virtual int StepCount
        {
            get
            {
                var stepsCount = (int)Math.Round((_max - _min) / _stepSize);
                var remainder = (_max - _min) % _stepSize;
                if (remainder != 0f) stepsCount++;

                return stepsCount;
            }
        }

        public virtual float Max
        {
            get { return _max; }
            set
            {
                _max = value;
                Utility.Clamp(_value, _min, _max);
                CalculateThresholds();
            }
        }

        public virtual float Min
        {
            get { return _min; }
            set
            {
                _min = value;
                Utility.Clamp(_value, _min, _max);
                CalculateThresholds();
            }
        }

        public virtual float StepSize
        {
            get { return _stepSize; }
            set
            {
                _stepSize = value;
                CalculateThresholds();
            }
        }

        public virtual float Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual IBounds Bounds
        {
            get { return _bounds; }
            set { _bounds = value; }
        }

        public virtual Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                CalculateThresholds();
            }
        }

        public virtual Vector2 Dimensions
        {
            get { return _dimensions; }
            set
            {
                _dimensions = value;
                CalculateThresholds();
            }
        }

        public virtual IScreen Screen
        {
            get { return _screen; }
            set { _screen = value; }
        }


        protected bool _clicked;
        protected bool _mouseInBounds;
        protected bool _focused;
        protected bool _visible;
        protected bool _enabled;
        protected int _tabIndex;
        protected float _max;
        protected float _min;
        protected float _stepSize;
        protected float _value;
        protected float _minThreshold;
        protected float _maxThreshold;
        protected float _screenStep;
        protected IBounds _bounds;
        protected IScreen _screen;
        protected Vector2 _position;
        protected Vector2 _dimensions;


        public BaseSlider(IBounds bounds, IScreen screen, Vector2 position, Vector2 dimensions, int tabIndex, float min, float max, float step, float value, bool visible = true, bool enabled = true)
        {
            _bounds = bounds;
            _screen = screen;
            _position = position;
            _dimensions = dimensions;
            _tabIndex = tabIndex;
            _max = max;
            _min = min;
            _stepSize = step;
            _value = value;
            _visible = visible;
            _enabled = enabled;
        }

        public virtual void Increment()
        {
            _value++;
            Utility.Clamp(_value, _min, _max);
        }

        public virtual void Decrement()
        {
            _value--;
            Utility.Clamp(_value, _min, _max);
        }

        public virtual void Focus()
        {
            _focused = true;
        }

        public virtual void Unfocus()
        {
            _focused = false;
        }

        public virtual void ReceiveMessage(Message message)
        {
            if (message is MouseButtonStatesMessage)
                HandleMouseButtonStateMessage(message as MouseButtonStatesMessage);
            else if (message is MouseMoveMessage)
                HandleMouseMoveMessage(message as MouseMoveMessage);
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);

        protected void HandleMouseButtonStateMessage(MouseButtonStatesMessage message)
        {
            if (!_clicked && _mouseInBounds && message.ButtonState["LeftButton"] == ButtonState.Pressed) _clicked = true;
            else if (_clicked && message.ButtonState["LeftButton"] == ButtonState.Released) _clicked = false;
        }

        protected void HandleMouseMoveMessage(MouseMoveMessage message)
        {
            if (Clicked)
            {
                if (message.Position.X <= _minThreshold) _value = _min;
                else if (message.Position.X >= _maxThreshold) _value = _max;
                else
                {
                    var relativeX = message.Position.X - _minThreshold;
                    var steps = (int)Math.Round(relativeX / _screenStep);
                    _value = _min + (_stepSize * steps);
                }
            }
            else
            {
                if (_bounds.Contains(message.Position))
                {
                    _mouseInBounds = true;
                    _focused = true;
                }
                else
                {
                    _mouseInBounds = false;
                    _focused = false;
                }
            }
        }

        protected void CalculateThresholds()
        {
            var _screenStep = _dimensions.X / StepCount;
            var _minThreshold = _position.X + (_screenStep / 2);
            var _maxThreshold = _position.X + _dimensions.X - (_screenStep / 2);
        }
    }
}