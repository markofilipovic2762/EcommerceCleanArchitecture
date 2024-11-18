using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Product> Products { get; }
    DbSet<Employee> Employees { get; }
    DbSet<Customer> Customers { get; }
    DbSet<Subcategory> Subcategories { get; }
    DbSet<Shipper> Shippers { get; }
    DbSet<OrderDetail> OrderDetails { get; }
    DbSet<Order> Orders { get; }
    DbSet<Supplier> Suppliers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
