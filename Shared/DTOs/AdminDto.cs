using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    //public record AdminDto 
    //{
       

    //    [Required]
    //    public int Id { get; init; }
    //    [Required]
    //    public string Name { get; init; } = string.Empty;
    //    [Required]
    //    public string Email { get; init; } = string.Empty;
    //    [Required]
    //    public string Phone { get; init; } = string.Empty;
    //    [Required]
    //    public string Password { get; init; } = string.Empty;
    //    [Required]
    //    public string AdminDegree { get; init; } = string.Empty;
    //}
    public record AdminDto(int id, string? name, string? password, string? phone, string? email, string? adminDegree);

}
