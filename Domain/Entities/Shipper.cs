using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Shipper: BaseAuditableEntity
{
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
