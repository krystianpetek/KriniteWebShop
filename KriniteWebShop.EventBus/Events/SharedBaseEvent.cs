namespace KriniteWebShop.EventBus.Events;
public class SharedBaseEvent
{
    public Guid Id { get; private set; }
    public DateTime CreationDate { get; private set; }

    public SharedBaseEvent(Guid id, DateTime creationDate)
    {
        Id = id;
        CreationDate = creationDate;
    }

    public SharedBaseEvent()
    {
        Id = Guid.NewGuid();
        CreationDate = DateTime.UtcNow;
    }
}
 