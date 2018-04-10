using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

public abstract class Entity
{
    /* Properties */
    public bool Visible
    {
        get { return _visible; }
        set { _visible = value; }
    }

    public World ParentWorld
    {
        get { return _parentWorld; }
        set { _parentWorld = value; }
    }

    public List<Component> Components
    {
        get { return _components; }
    }

    public List<DrawableComponent> DrawableComponents
    {
        get { return _drawableComponents; }
    }

    /* Variables */
    protected bool _visible;
    protected World _parentWorld;
    protected List<Component> _components;
    protected List<DrawableComponent> _drawableComponents; // All components in _drawableComponents should also be in _components

    /* Methods */
    public Entity(World parentWorld, bool visible = false)
    {
        _visible = visible;
        _parentWorld = parentWorld;

        _components = new List<Component>();
        _drawableComponents = new List<DrawableComponent>();
    }
    
    public virtual void Update(GameTime gameTime)
    {
        // Removes duplicate component types
        _components = new List<Component>(_components.Distinct(new ComponentTypeComparer()));

        foreach(Component comp in _components)
            comp.Update(gameTime);
    }

    public virtual void Draw(GameTime gameTime)
    {
        foreach (DrawableComponent dComp in _drawableComponents)
            dComp.Draw(gameTime);
    }

    /// <summary>
    /// Attaches a component to an entity.
    /// </summary>
    /// <param name="component">The component to be attached to the entity.</param>
    public virtual void Add(Component component)
    {
        if (!_components.Contains(component))
        {
            component.ParentEntity = this;
            _components.Add(component);
        }

        if (component is DrawableComponent && !_drawableComponents.Contains((DrawableComponent)component))
        {
            ((DrawableComponent)component).Visible = _visible;
            _components.Add(component);
        }
    }
    
    /// <summary>
    /// Removes a component from an entity.
    /// </summary>
    /// <param name="component">The component to be removed from the entity.</param>
    public virtual void Remove(Component component)
    {
        if (_components.Contains(component))
        {
            component.ParentEntity = null;
            _components.Remove(component);
        }

        if (component is DrawableComponent && _drawableComponents.Contains((DrawableComponent)component))
            _drawableComponents.Remove((DrawableComponent)component);
    }
}