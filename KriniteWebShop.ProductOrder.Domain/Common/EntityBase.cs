namespace KriniteWebShop.ProductOrder.Domain.Common;
public abstract class EntityBase
{
    public Guid Id { get; protected set; }
    public required string CreatedBy { get; set; }
    public required DateTime CreatedDate { get; set;}
    public required string LastModifiedBy { get; set; }
    public DateTime? LastModifiedDate { get; set; }
}
