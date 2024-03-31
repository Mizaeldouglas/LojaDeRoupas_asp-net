using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace LojaDeRoupas.Models
{
    [Table("Clothings")]
    public class Clothing
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18, 2)")] public decimal Price { get; set; }

        public int Stock { get; set; }
        public string Image { get; set; } = string.Empty;

        public virtual ICollection<ClothingColor> ClothingColors { get; set; }
    }
}