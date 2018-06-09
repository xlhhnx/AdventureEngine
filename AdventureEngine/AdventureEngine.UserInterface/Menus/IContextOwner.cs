using System.Collections.Generic;

public interface IContextOwner : IUserInterfaceObject
{
    List<IMenuOption> ContextOptions { get; set; }

    void OpenContext();
}