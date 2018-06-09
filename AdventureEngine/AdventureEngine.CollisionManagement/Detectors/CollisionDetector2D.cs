using Microsoft.Xna.Framework;
using System;
using System.Linq;

public class CollisionDetector2D
{
    protected IWorld _world;

    public CollisionDetector2D(IWorld world)
    {
        _world = world;
    }

    public Collision2D DetectCollision(string entity1, string entity2)
    {
        Collision2D collision = null;
        Shape shape1 = null;
        Shape shape2 = null;
        Position position1 = null;
        Position position2 = null;
        if (_world.Entities.ContainsKey(entity1))
        {
            shape1 = _world.Entities[entity1].Where(c => c is Shape)
                                             .FirstOrDefault()
                                             as Shape;
            position1 = _world.Entities[entity1].Where(c => c is Position)
                                             .FirstOrDefault()
                                             as Position;
        }
        if (_world.Entities.ContainsKey(entity2))
        {
            shape2 = _world.Entities[entity2].Where(c => c is Shape)
                                             .FirstOrDefault()
                                             as Shape;
            position2 = _world.Entities[entity2].Where(c => c is Position)
                                             .FirstOrDefault()
                                             as Position;
        }

        if (shape1 == null || shape2 == null || position1 == null || position2 == null)
        {
            return null;
        }


        if (shape1 is Circle && shape2 is OrientedBox)
        {
            collision = CircleToOrientedBox(shape1 as Circle, shape2 as OrientedBox, position1, position2);
        }
        else if (shape2 is Circle && shape1 is OrientedBox)
        {
            collision = CircleToOrientedBox(shape2 as Circle, shape1 as OrientedBox, position1, position2);
        }
        else if (shape1 is Circle && shape2 is Circle)
        {
            collision = CircleToCircle(shape1 as Circle, shape2 as Circle, position1, position2);
        }
        else if (shape1 is OrientedBox && shape2 is OrientedBox)
        {
            collision = OrientedBoxToOrientedBox(shape1 as OrientedBox, shape2 as OrientedBox, position1, position2);
        }

        return collision;
    }

    public Collision2D CircleToOrientedBox(Circle circle, OrientedBox box, Position position1, Position position2)
    {
        var truePos1 = position1._Position + circle.PositionOffset;
        var truePos2 = position2._Position + box.PositionOffset;

        var translation = truePos2 - truePos1;
        var closest = translation;

        closest.X = Clamp(closest.X, -box.Extent.X, box.Extent.X);
        closest.Y = Clamp(closest.Y, -box.Extent.Y, box.Extent.Y);

        var inside = false;
        if (translation == closest)
        {
            inside = true;
            if (Math.Abs(translation.X) > Math.Abs(translation.Y))
            {
                if (closest.X > 0)
                    closest.X = box.Extent.X;
                else
                    closest.X = -box.Extent.X;
            }
            else
            {
                if (closest.Y > 0)
                    closest.Y = box.Extent.Y;
                else
                    closest.Y = -box.Extent.Y;
            }
        }

        var normal = translation - closest;
        var radius = circle.Radius;
        if (!inside && translation.LengthSquared() > radius * radius)
        {
            return null;
        }

        var distance = translation.Length();
        var penetration = radius - distance;
        if (inside)
        {
            normal = -translation;
        }
        else
        {
            normal = translation;
        }

        return new Collision2D(circle.EntityId, box.EntityId, penetration, circle, box, normal);
    }

    public Collision2D CircleToCircle(Circle circle1, Circle circle2, Position position1, Position position2)
    {
        var truePos1 = position1._Position + circle1.PositionOffset;
        var truePos2 = position2._Position + circle2.PositionOffset;

        var translation = truePos2 - truePos1;
        var cumulativeRadius = circle1.Radius + circle2.Radius;
        if (translation.LengthSquared() > cumulativeRadius * cumulativeRadius)
        {
            return null;
        }

        var penetration = 0f;
        var normal = Vector2.Zero;
        var distance = translation.Length();
        if (distance == 0)
        {
            penetration = circle1.Radius;
            normal = new Vector2(1, 0);
        }
        else
        {
            penetration = cumulativeRadius - distance;
            normal = translation / distance;
        }

        return new Collision2D(circle1.EntityId, circle2.EntityId, penetration, circle1, circle2, normal);
    }

    public Collision2D OrientedBoxToOrientedBox(OrientedBox box1, OrientedBox box2, Position position1, Position position2)
    {
        var truePos1 = position1._Position + box1.PositionOffset;
        var truePos2 = position2._Position + box2.PositionOffset;

        var normal = Vector2.Zero;
        var penetration = 0f;
        var translation = truePos2 - truePos1;
        var xOverlap = box1.Extent.X + box2.Extent.X - Math.Abs(translation.X);
        if (xOverlap > 0)
        {
            var yOverlap = box1.Extent.Y + box2.Extent.Y - Math.Abs(translation.Y);

            if (yOverlap > 0)
            {
                if (xOverlap > yOverlap)
                {
                    if (translation.X < 0)
                    {
                        normal = new Vector2(-1, 0);
                    }
                    else
                    {
                        normal = new Vector2(1, 0);
                    }
                    penetration = xOverlap;
                }
                else
                {
                    if (translation.X < 0)
                    {
                        normal = new Vector2(0, -1);
                    }
                    else
                    {
                        normal = new Vector2(0, 1);
                    }
                    penetration = yOverlap;
                }

                return new Collision2D(box1.EntityId, box2.EntityId, penetration, box1, box2, normal);
            }
        }
        return null;
    }

    public float Clamp(float value, float minimum, float maximum)
    {
        if (value < minimum)
        {
            value = minimum;
        }
        else if (value < maximum)
        {
            value = maximum;
        }

        return value;
    }
}