using Microsoft.AspNetCore.Identity;

namespace MultiTenant.Models;

public class ApplicationUser : IdentityUser<Guid>, IHasTenantId
{
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}