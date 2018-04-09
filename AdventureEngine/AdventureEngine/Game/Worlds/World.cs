using Microsoft.Xna.Framework;
using System.Collections.Generic;

public abstract class World
{
    public bool Visible { get; set; }
    public List<Entity> Entities { get; }


    protected bool _visible;
    protected List<Entity> _entities;


    public World(bool visible = false)
    {
        _visible = visible;
        _entities = new List<Entity>();
    }


    public virtual void Update(GameTime gameTime)
    {
        foreach(Entity ent in _entities)
            ent.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime)
    {
        foreach(Entity ent in _entities)
            ent.Draw(gameTime);
    }

    /// <summary>
    /// Attaches an entity to a world.
    /// </summary>
    /// <param name="entity">The entity to be attached.</param>
    public virtual void Add(Entity entity)
    {
        if (!_entities.Contains(entity))
        {
            entity.ParentWorld = this;
            _entities.Add(entity);
        }
    }

    /// <summary>
    /// Removes an entity from a world.
    /// </summary>
    /// <param name="entity">The entity to be removed.</param>
    public virtual void Remove(Entity entity)
    {
        if (_entities.Contains(entity))
        {
            entity.ParentWorld = null;
            _entities.Remove(entity);
        }
    }
}