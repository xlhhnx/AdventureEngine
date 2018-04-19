using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

public class InputManager
{
    // Properties
    public List<InputController> InputControllers
    {
        get { return _inputControllers; }
        set { _inputControllers = value; }
    }

    // Variables
    protected List<InputController> _inputControllers;

    // Methods
    public InputManager()
    {
        _inputControllers = new List<InputController>();
    }

    public void Update(GameTime gameTime)
    {
        foreach (InputController controller in _inputControllers)
            controller.Update(gameTime);
    }
}