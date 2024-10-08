﻿using System.Runtime.CompilerServices;

namespace Portal.Domain.Common.Models;

public abstract class Entity<TId> : IEquatable<Entity<TId>>
    where TId : notnull
{
    public TId Id { get; private set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    protected Entity()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    { }
    protected Entity(TId entityId)
    {
        Id = entityId;
    }
    
    public bool Equals(Entity<TId>? other)
    {
        return Equals((object?) other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity &&
            Id.Equals(entity.Id);
    }
    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        return Equals(left, right); 
    }
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }
    public override int GetHashCode() 
    {
        return Id.GetHashCode();
    }
}
