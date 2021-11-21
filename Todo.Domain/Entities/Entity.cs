namespace Todo.Domain.Entities;

internal abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public bool Equals(Entity? other)
    {
        return Id == other?.Id;
    }
}