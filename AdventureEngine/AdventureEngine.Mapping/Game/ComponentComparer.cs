using System.Collections.Generic;

public class ComponentComparer : IEqualityComparer<IComponent>
{
    public bool Equals(IComponent x, IComponent y)
    {
        return x.Name == y.Name;
    }

    public int GetHashCode(IComponent obj)
    {
        return obj.GetHashCode();
    }
}