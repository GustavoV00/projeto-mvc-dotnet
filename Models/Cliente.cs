using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
public class Cliente
{

    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Sobrenome { get; set; }

    [Required]
    public string? Email { get; set; }

    [Required]
    public string? Endereco { get; set; }
}