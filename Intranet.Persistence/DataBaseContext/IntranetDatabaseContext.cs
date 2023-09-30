using Intranet.Domain.Models;
using Intranet.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;

namespace Intranet.Persistence.DataBaseContext;

public class IntranetDatabaseContext: DbContext
{
    public IntranetDatabaseContext(DbContextOptions<IntranetDatabaseContext> options): base(options) 
    {
        
    }

    public DbSet<News> News { get; set; }
    public DbSet<EmployeeDirectory> EmployeeDirectory { get; set; }
    public DbSet<Event> Event { get; set;}
    public DbSet<StoredFile> StoredFile { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var dateNow = DateTime.Now;
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.DateUpdated = dateNow;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = dateNow;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}
