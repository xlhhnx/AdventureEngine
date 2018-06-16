using AdventureEngine.Messaging;
using AdventureEngine.UserInterface.Controls;
using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Screens
{
    public interface IScreen : IUserInterfaceObject, ISubscriber
    {
        bool Focused { get; }
        List<IControl> Controls { get; }
    }
}