using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.VillaDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MagicVilla_VillaAPI.Logging;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[Controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase 
    {
        private readonly Ilogging _logger;
        public VillaAPIController(Ilogging logger)
        {
            _logger = logger;  
        }
        [ProducesResponseType(200)]
        [HttpGet]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.Log("Get all villa details", " ");
            return Ok(Villastore.Villalist);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
         
        [HttpGet("{id:int}",Name ="GetVilla")]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.Log("Bad Request ID - "+id,"error");
                return BadRequest();
            }
                var villa= Villastore.Villalist.FirstOrDefault(u => u.Id == id);
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
            if(Villastore.Villalist.FirstOrDefault(u => u.Name.ToLower()==villaDTO.Name.ToLower())!=null)
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
            villaDTO.Id = Villastore.Villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
            
            Villastore.Villalist.Add(villaDTO);
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
            var villa = Villastore.Villalist.FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return StatusCode(StatusCodes.Status404NotFound);
            Villastore.Villalist.Remove(villa);
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
            var villa = Villastore.Villalist.FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return StatusCode(StatusCodes.Status404NotFound);
            villa.Id=villaDTO.Id;
            villa.Name=villaDTO.Name;
            villa.Sqrft=villaDTO.Sqrft;
            villa.Occupancy=villaDTO.Occupancy; 
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
            var villa = Villastore.Villalist.FirstOrDefault(u => u.Id == id);
            if (villa == null)
                return StatusCode(StatusCodes.Status404NotFound);
            patchDTO.ApplyTo(villa, ModelState);
                if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return NoContent();

        }

    }
}
