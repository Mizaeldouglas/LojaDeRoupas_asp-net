using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDeRoupas.Models;

[Table("ClothingColors")]
public class ClothingColor
{
    public int ClothingId { get; set; }
    public Clothing Clothing { get; set; }

    public int ColorId { get; set; }
    public Color Color { get; set; }
}
