using Microsoft.AspNetCore.Identity;

namespace MultiTenant.Models;

public class ApplicationUser : IdentityUser<Guid>, IHasTenantId
{
    public Guid TenantId { get; set; }
    public required Tenant Tenant { get; set; }
}