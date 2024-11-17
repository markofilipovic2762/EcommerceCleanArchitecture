using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Supplier : BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Contact { get; set; } = null!;
    public string? Address { get; set; }
    public string? City { get; set; }
}
