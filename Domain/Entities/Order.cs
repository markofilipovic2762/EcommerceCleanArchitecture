using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Order : BaseAuditableEntity
{
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = null!;
    public int? EmployeeId { get; set; }
    public virtual Employee? Employee { get; set; }
    
    public decimal? TotalPrice { get;set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int? ShipVia { get; set; } 
    public string ShipName { get; set; } = null!;
    public string ShipAddress { get; set; } = null!;
    public string ShipCity { get; set; } = null!;
    public int? ShipPostalCode { get; set; }
    public virtual List<Product> Products { get; } = [];
    public virtual List<OrderDetail> OrderDetails { get; } = [];

}
