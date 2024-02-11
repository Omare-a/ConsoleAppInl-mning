using Azure.Identity;
using ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Context;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{

    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<CustomerEntity> Customers { get; set; }
    public virtual DbSet<OrderEntity> Orders { get; set; }
    public virtual DbSet<OrderProductRowEntity> OrderProductRow {  get; set; }
    public virtual DbSet<RoleEntity> RoleEntities { get; set; }

  

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderProductRowEntity>()
        .HasKey(e => new { e.OrderId, e.RowId });
    }
}


