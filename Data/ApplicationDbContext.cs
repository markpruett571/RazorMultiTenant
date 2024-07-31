using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Models;

namespace MultiTenant.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IHasTenantId))
        {
            entry.Property("TenantId").IsModified = false;
        }

        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity is IHasTenantId))
        {
            entry.Property("TenantId").IsModified = false;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
}
