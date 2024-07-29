namespace MultiTenant.Models;

public interface IHasTenantId
{
    Guid TenantId { get; set; }
    Tenant? Tenant { get; set; }
}
