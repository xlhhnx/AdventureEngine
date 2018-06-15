using System.Collections.Generic;

namespace AdventureEngine.UserInterface.Menus
{
    public interface IContextOwner : IUserInterfaceObject
    {
        List<IMenuOption> ContextOptions { get; set; }

        void OpenContext();
    }
}