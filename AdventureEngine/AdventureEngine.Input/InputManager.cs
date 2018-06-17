using System.Collections.Generic;

namespace AdventureEngine.Input
{
    public class InputManager
    {
        protected List<IController> _inputControllers;

        /// <summary>
        /// Creates an input manager.
        /// </summary>
        public InputManager()
        {
            _inputControllers = new List<IController>();
        }

        /// <summary>
        /// Updates all controllers in the input manager.
        /// </summary>
        public void Update()
        {
            foreach (IController ctrl in _inputControllers)
            {
                ctrl.Update();
            }
        }

        /// <summary>
        /// Determines if a controller is in the input manager.
        /// </summary>
        /// <param name="controller">The controller to check.</param>
        /// <returns>A flag deterining if the controller is in the input manager.</returns>
        public bool ContainsController(IController controller)
        {
            return _inputControllers.Contains(controller);
        }

        /// <summary>
        /// Adds a controller to the input manager.
        /// </summary>
        /// <param name="controller">The controller to add.</param>
        public void AddController(IController controller)
        {
            if (!ContainsController(controller))
            {
                _inputControllers.Add(controller);
            }
        }

        /// <summary>
        /// Removes a controller from the input manager.
        /// </summary>
        /// <param name="controller">The controller to remove.</param>
        public void RemoveController(IController controller)
        {
            if (ContainsController(controller))
            {
                _inputControllers.Remove(controller);
            }
        }
    }
}