using System.Collections.Generic;

public interface IScreen : IUserInterfaceObject, ISubscriber
{
    List<IControl> Controls { get; set; }
}