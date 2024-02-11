using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Entities;

public class OrderEntity
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    [ForeignKey(nameof(CustomerEntity))]
    public int CustomerId { get; set; }

    public virtual CustomerEntity Customer { get; set; } = null!;
    public virtual ICollection<OrderProductRowEntity> OrderRowEntities { get; set; } = new HashSet<OrderProductRowEntity>();
    
}

