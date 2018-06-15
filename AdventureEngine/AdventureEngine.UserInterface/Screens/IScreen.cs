using AdventureEngine.UserInterface.Controls;
using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Screens
{
    public interface IScreen : IUserInterfaceObject, ISubscriber
    {
        List<IControl> Controls { get; set; }
    }
}