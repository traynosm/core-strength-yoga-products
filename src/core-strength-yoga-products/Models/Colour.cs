using System.ComponentModel.DataAnnotations;

namespace core_strength_yoga_products.Models
{
    public class Colour
    {
        [Key]
        public int Id { get; set; }
        public string ColourName { get; set; }

        public Colour(int id, string colourName) 
        {
            Id = id;
            ColourName = colourName;
        }
    }
}
