using MagicVilla_VillaAPI.Models.VillaDTO;

namespace MagicVilla_VillaAPI.Data
{
    public static class Villastore
    {
        public static List<VillaDTO> Villalist = new List<VillaDTO>() { new VillaDTO { Id = 1, Name = "Pool View",Sqrft=900,Occupancy=4 }, new VillaDTO { Id = 2, Name = "Baech View",Sqrft=1500,Occupancy=6 } };
    }
}
