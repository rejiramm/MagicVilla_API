﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.VillaDTO
{
    public class VillaUpdateDTO
    {
<<<<<<< HEAD
        [Required]
=======
>>>>>>> 198ea108a6242420400127a6d135e2557c8d7884
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
<<<<<<< HEAD
        public string Details { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public int Sqft { get; set; }
        [Required]
=======
        [Required]
        public string Details { get; set; }
        public double Rate { get; set; }    
        public int Sqft { get; set; }
>>>>>>> 198ea108a6242420400127a6d135e2557c8d7884
        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
