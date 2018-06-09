using Microsoft.Xna.Framework;
using System;

public class Circle : Shape
{
    public override float Area { get { return (float)(Math.PI * _radius * _radius); } }

    /// <summary>
    /// Gets and Sets the radius of the circle.
    /// </summary>
    public float Radius
    {
        get { return _radius; }
        set { _radius = value; }
    }

    protected float _radius;

    public Circle(string entityId, string name, float radius, Vector2 positionOffset) : base(entityId, name, positionOffset)
    {
        _radius = radius;
    } 
}