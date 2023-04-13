using FluentValidator;

namespace SilvioStore.Shared.Entities;

public abstract class Entity : Notifiable
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    
    public Guid Id { get; private set; }
}