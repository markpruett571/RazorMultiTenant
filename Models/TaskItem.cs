namespace MultiTenant.Models;

public class TaskItem: IHasTenantId
{
    public int Id { get; set; }
    public Guid TenantId { get; set; }
    public Tenant? Tenant { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
}