using ConsoleApp.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Dto;
public class OrderProductRowDto
{
    public int RowId { get; set; }
    public int OrderId { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Price { get; set; }
}
