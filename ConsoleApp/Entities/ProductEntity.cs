using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Entities;

public class ProductEntity
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string ProductName { get; set; } = null!;

    [Required]
    [Column(TypeName = "money")]
    public decimal Price { get; set; }

    public virtual ICollection<OrderProductRowEntity> ProductRowEntities { get; set; } = new HashSet<OrderProductRowEntity>();
}

