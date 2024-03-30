namespace LojaDeRoupas.Models;

public class Clothing
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Image { get; set; } = string.Empty;
    
    // public int CategoryId { get; set; }
    public int BrandId { get; set; }
    public Brand Brand { get; set; }

    public ICollection<Color> Colors { get; set; } // Relacionamento muitos para muitos com cores

    
}