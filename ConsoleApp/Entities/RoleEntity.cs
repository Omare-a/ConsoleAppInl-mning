using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Entities;

public class RoleEntity
{
    [Key]
    public int RoleId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar(100)")]
    public string RoleName { get; set; } = null!;

    public virtual ICollection<RoleEntity> Roles { get; set; } = new HashSet<RoleEntity>();

}

