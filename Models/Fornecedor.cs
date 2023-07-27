using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models;
public class Fornecedor
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Nome { get; set; }

    [Required]
    public string? Estado { get; set; }

    [StringLength(60, MinimumLength = 3)]
    [Required]
    public string? Cidade { get; set; }

    [Required]
    public string? Contato { get; set; }

    [Required]
    public string? Endereco { get; set; }
}