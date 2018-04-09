using System;
using System.Collections.Generic;

public class ComponentTypeComparer : IEqualityComparer<Component>
{
    public bool Equals(Component x, Component y)
    {
        return x.GetType() == y.GetType();
    }

    public int GetHashCode(Component obj)
    {
        return obj.GetType().GetHashCode();
    }
}