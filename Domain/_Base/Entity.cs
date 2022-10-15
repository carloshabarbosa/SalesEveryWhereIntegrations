using System.ComponentModel.DataAnnotations;

namespace Domain._Base;

public abstract class Entity<TId, TEntity>
          where TId : struct
          where TEntity : Entity<TId, TEntity>
{
    public virtual TId Id { get; protected set; }

    [Required]
    public DateTime CreatedAt { get; private set; }

    public DateTime? ChangedAt { get; private set; }

    protected Entity()
    {
        Id = default;
        CreatedAt = DateTime.UtcNow;
    }

    public override bool Equals(object? obj)
    {
        var compareTo = obj as Entity<TId, TEntity>;

        if (ReferenceEquals(this, compareTo)) return true;
        if (compareTo is null) return false;

        return Id.Equals(compareTo.Id);
    }

    public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();
}