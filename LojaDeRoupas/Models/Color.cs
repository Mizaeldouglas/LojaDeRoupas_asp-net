using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaDeRoupas.Models
{
    [Table("Colors")]
    public class Color
    {
        public Color()
        {
            ClothingColors = new List<ClothingColor>();
        }

        [Key]
        public int Id { get; set; }

        [Column("ColorName")]
        public string Name { get; set; } = string.Empty;

        public  ICollection<ClothingColor> ClothingColors { get; set; }

        
    }
}