using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.VillaDTO
{
    public class VillaCreateDTO
    {
        
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public string Details { get; set; }
        public double Rate { get; set; }    
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
