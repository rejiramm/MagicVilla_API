﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.VillaDTO
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public int Sqrft { get; set; }

        public int Occupancy { get; set; }
    }
}