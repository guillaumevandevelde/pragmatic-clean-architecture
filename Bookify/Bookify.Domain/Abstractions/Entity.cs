namespace Bookify.Domain.Abstractions;

public class Entity
{
    private readonly List<IDomainEvent> _domainEvents = [];
    
    public Guid Id { get; init; }
    
    protected Entity(Guid id)
    {
        Id = id;
    }
    
    public IReadOnlyList<IDomainEvent> GetDomainEvents() => _domainEvents.ToList();
    public void ClearDomainEvents() => _domainEvents.Clear();
    public void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    
}