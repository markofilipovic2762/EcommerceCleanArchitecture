namespace Domain.Entities;

public class Subcategory: BaseAuditableEntity
{
    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}