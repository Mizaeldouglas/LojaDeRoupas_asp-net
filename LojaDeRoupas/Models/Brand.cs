using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDeRoupas.Models;

public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
}