using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Employee: BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Title { get; set; } = null!;
    public DateOnly? BirthDate { get; set; }
    public DateOnly? HireDate { get; set; }
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public int? SuperiorId { get; set; }

    [ForeignKey("SuperiorId")]
    public virtual Employee? Superior { get; set; }
    public byte[]? Photo { get; set; }

}
