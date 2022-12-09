using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Sample.Data.Entities;

public class UserMapped
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = default!;
    [MaxLength(50)]
    public string Email { get; set; } = default!;
    [MaxLength(100)]
    public string Country { get; set; } = default!;
    [MaxLength(2000)]
    public string Bio { get; set; } = default!;
}
