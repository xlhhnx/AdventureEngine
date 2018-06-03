using Microsoft.Xna.Framework;
using System;
using System.Linq;

public class Physics2DCollisionResolver
{
    protected IWorld _world;

    public Physics2DCollisionResolver(IWorld world)
    {
        _world = world;
    }

    public void ResolveCollision(Collision collision)
    {
        Position position1 = null;
        Position position2 = null;
        Velocity velocity1 = null;
        Velocity velocity2 = null;
        Mass mass1 = null;
        Mass mass2 = null;
        Restitution restitution1 = null;
        Restitution restitution2 = null;
        Friction friction1 = null;
        Friction friction2 = null;
        Bounds shape1 = null;
        Bounds shape2 = null;

        if (_world.Entities.ContainsKey(collision.Entity1))
        {
            position1 = _world.Entities[collision.Entity1].Where(c => c is Position)
                                                          .FirstOrDefault()
                                                          as Position;
            velocity1 = _world.Entities[collision.Entity1].Where(c => c is Velocity)
                                                          .FirstOrDefault()
                                                          as Velocity;
            mass1 = _world.Entities[collision.Entity1].Where(c => c is Mass)
                                                      .FirstOrDefault()
                                                      as Mass;
            restitution1 = _world.Entities[collision.Entity1].Where(c => c is Restitution)
                                                             .FirstOrDefault()
                                                             as Restitution;
            friction1 = _world.Entities[collision.Entity1].Where(c => c is Friction)
                                                          .FirstOrDefault()
                                                          as Friction;
            shape1 = _world.Entities[collision.Entity1].Where(c => c is Bounds)
                                                       .FirstOrDefault()
                                                       as Bounds;
        }
        if (_world.Entities.ContainsKey(collision.Entity2))
        {
            position2 = _world.Entities[collision.Entity2].Where(c => c is Position)
                                                          .FirstOrDefault()
                                                          as Position;
            velocity2 = _world.Entities[collision.Entity2].Where(c => c is Velocity)
                                                          .FirstOrDefault()
                                                          as Velocity;
            mass2 = _world.Entities[collision.Entity2].Where(c => c is Mass)
                                                      .FirstOrDefault()
                                                      as Mass;
            restitution2 = _world.Entities[collision.Entity2].Where(c => c is Restitution)
                                                             .FirstOrDefault()
                                                             as Restitution;
            friction2 = _world.Entities[collision.Entity2].Where(c => c is Friction)
                                                          .FirstOrDefault()
                                                          as Friction;
            shape2 = _world.Entities[collision.Entity2].Where(c => c is Bounds)
                                                       .FirstOrDefault()
                                                       as Bounds;
        }

        var truePos1 = position1._Position + shape1.PositionOffset;
        var truePos2 = position2._Position + shape2.PositionOffset;

        // Calculate velocities
        var relativeVelocity = velocity1._Velocity - velocity2._Velocity;
        var contactVelocity = Vector2.Dot(relativeVelocity, collision.Normal);
        if (contactVelocity > 0)
        {
            return;
        }
        var restitution = MathHelper.Min(restitution1._Restitution, restitution2._Restitution);
        var impulseScalar = -(1.0f + restitution) * contactVelocity;
        impulseScalar /= mass1.InverseMass + mass2.InverseMass;
        var impulse = impulseScalar * collision.Normal;
        velocity1._Velocity -= mass1.InverseMass * impulse;
        velocity2._Velocity += mass2.InverseMass * impulse;

        // Calculate friction
        var tangent = relativeVelocity - Vector2.Dot(relativeVelocity, collision.Normal) * collision.Normal;
        tangent.Normalize();
        var impulseScalarTangent = contactVelocity / (mass1.InverseMass + mass2.InverseMass);
        var mu = Math.Sqrt((friction1.StaticFriction * friction1.StaticFriction) + (friction2.StaticFriction * friction2.StaticFriction));
        var frictionImpulse = Vector2.Zero;
        if (Math.Abs(impulseScalarTangent) < impulseScalar * mu)
        {
            frictionImpulse = impulseScalarTangent * tangent;
        }
        else
        {
            var dynamicFriction = (float)Math.Sqrt((friction1.DynamicFriction * friction1.DynamicFriction) + (friction2.DynamicFriction * friction2.DynamicFriction));
            frictionImpulse = -impulseScalar * tangent * dynamicFriction;
        }
        velocity1._Velocity -= mass1.InverseMass * frictionImpulse;
        velocity2._Velocity -= mass2.InverseMass * frictionImpulse;
    }

    public void PositionalCorrection(Collision collision)
    {
        const float slop = 0.01f;
        const float percent = 0.2f;

        Position position1 = null;
        Position position2 = null;
        Mass mass1 = null;
        Mass mass2 = null;

        if (_world.Entities.ContainsKey(collision.Entity1))
        {
            position1 = _world.Entities[collision.Entity1].Where(c => c is Position)
                                                          .FirstOrDefault()
                                                          as Position;
            mass1 = _world.Entities[collision.Entity1].Where(c => c is Mass)
                                                      .FirstOrDefault()
                                                      as Mass;
        }
        if (_world.Entities.ContainsKey(collision.Entity2))
        {
            position2 = _world.Entities[collision.Entity2].Where(c => c is Position)
                                                          .FirstOrDefault()
                                                          as Position;
            mass2 = _world.Entities[collision.Entity2].Where(c => c is Mass)
                                                      .FirstOrDefault()
                                                      as Mass;
        }
                
        var correction = (Math.Max(collision.Penetration - slop, 0f) / (mass1.InverseMass + mass2.InverseMass)) * percent * collision.Normal;
        position1._Position -= mass1.InverseMass * correction;
        position2._Position += mass2.InverseMass * correction;
    }
}