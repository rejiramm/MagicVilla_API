using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.VillaDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
//using MagicVilla_VillaAPI.Logging;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[Controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase 
    {
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ApplicationDbContext db)
        {
            _db = db;
        }

        
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            
            return Ok(_db.Villas.ToList());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         
        [HttpGet("{id:int}",Name ="GetVilla")]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
               
                return BadRequest();
            }
                var villa= _db.Villas.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            //if(!ModelState.IsValid)
                //return BadRequest();
            if(_db.Villas.FirstOrDefault(u => u.Name.ToLower()==villaDTO.Name.ToLower())!=null)
            {
                ModelState.AddModelError("Custom Error", "Villa already exists");
                return BadRequest(ModelState);
            }


            if (villaDTO == null)
            {
                return Ok(BadRequest(villaDTO));
            }
            if (villaDTO.Id>0)
            {
                return Ok(StatusCodes.Status500InternalServerError);
            }
            // villaDTO.Id = Villastore.Villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

            //Villastore.Villalist.Add(villaDTO);
            Villa model = new()
            {
                Name = villaDTO.Name,
                Id = villaDTO.Id,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
            _db.Villas.Add(model);
            _db.SaveChanges();  
            return CreatedAtRoute("GetVilla",new { id = villaDTO.Id },villaDTO);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [HttpDelete("{id:int}", Name="DeleteVilla")]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
                return StatusCode(StatusCodes.Status400BadRequest);
            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return StatusCode(StatusCodes.Status404NotFound);
            _db.Villas.Remove(villa);
            _db.SaveChanges(); 
            return NoContent();
                
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public IActionResult UpdateVilla(int id, [FromBody]VillaDTO villaDTO)
        {
            if (id == 0||(villaDTO.Id!=id))
                return StatusCode(StatusCodes.Status400BadRequest);
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return StatusCode(StatusCodes.Status404NotFound);
            Villa model = new()
            {
                Name = villaDTO.Name,
                Id = villaDTO.Id,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
            _db.Villas.Update(model);
            
            return NoContent();

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        [HttpPatch("{id:int}", Name = "UpdatepartiallyVilla")]
        public IActionResult UpdatepartiallyVilla(int id,JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (patchDTO == null || (id==0))
                return StatusCode(StatusCodes.Status400BadRequest);
            var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return StatusCode(StatusCodes.Status404NotFound);
            VillaDTO villaDTO = new()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                Occupancy = villa.Occupancy,
                ImageUrl = villa.ImageUrl,
                Amenity = villa.Amenity

            };
            patchDTO.ApplyTo(villaDTO, ModelState);
                if(!ModelState.IsValid)
                return BadRequest(ModelState);
            Villa model = new()
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Occupancy = villaDTO.Occupancy,
                ImageUrl = villaDTO.ImageUrl,
                Amenity = villaDTO.Amenity
            };
            _db.Update(model);
            _db.SaveChanges();
            return NoContent();

        }

    }
}
