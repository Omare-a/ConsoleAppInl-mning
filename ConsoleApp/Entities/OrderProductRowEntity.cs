using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Entities;

public class OrderProductRowEntity
{
    [Key]
    public int RowId { get; set; }


    [Key]
    [ForeignKey(nameof(OrderEntity))]
    public int OrderId { get; set; }
    public virtual OrderEntity Order { get; set; } = null !;


    [Required]
    [ForeignKey(nameof(ProductEntity))]
    public int ProductId { get; set; }
    public virtual ProductEntity Product { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }
}

