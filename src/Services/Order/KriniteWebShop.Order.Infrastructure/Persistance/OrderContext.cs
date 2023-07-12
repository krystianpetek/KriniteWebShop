using KriniteWebShop.Order.Domain.Common;
using KriniteWebShop.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KriniteWebShop.Order.Infrastructure.Persistance;
public class OrderContext : DbContext
{
	public OrderContext(DbContextOptions<OrderContext> dbContextOptions) : base(dbContextOptions) { }

	public DbSet<OrderEntity> Orders { get; set; }

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		foreach (var entry in ChangeTracker.Entries<EntityBase>())
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedDate = DateTime.Now;
					entry.Entity.CreatedBy = "krystianpetek2";
					break;

				case EntityState.Modified:
					entry.Entity.LastModifiedDate = DateTime.Now;
					entry.Entity.LastModifiedBy = "krystianpetek2";
					break;
			}
		}

		return base.SaveChangesAsync(cancellationToken);
	}
}
