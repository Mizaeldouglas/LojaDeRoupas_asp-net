using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDeRoupas.Models;

public class Color
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    [ForeignKey("Clothing")]
    public int ClothingId { get; set; }
    public Clothing Clothing { get; set; }
}