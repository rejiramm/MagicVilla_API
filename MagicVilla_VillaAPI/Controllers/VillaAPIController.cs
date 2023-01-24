using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.VillaDTO;
using MagicVilla_VillaAPI.Repositories.IRepositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Net;
//using MagicVilla_VillaAPI.Logging;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[Controller]")]
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly IVillarepository _dbvilla;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaAPIController(IVillarepository dbvilla, IMapper mapper)
        {
            _dbvilla = dbvilla;
            _mapper = mapper;
            this._response = new();
        }


        
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {

                List<Villa> villalist = await _dbvilla.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaDTO>>(villalist);
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

            return _response;

        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet("{id:int}", Name = "GetVilla")]
        public async Task<ActionResult<APIResponse>> GetVillaAsync(int id)
        {
            try
            {

                if (id == 0)
                {

                    return BadRequest();
                }
                var villa = await _dbvilla.GetAsync(u => u.Id == id);
                if (villa == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

            return _response;
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
<<<<<<< Updated upstream
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
=======
        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO createDTO)
>>>>>>> Stashed changes
        {
            try
            {
                //if(!ModelState.IsValid)
                //return BadRequest();
<<<<<<< Updated upstream
            if(_db.Villas.FirstOrDefault(u => u.Name.ToLower()==villaDTO.Name.ToLower())!=null)
=======
                if (await _dbvilla.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Custom Error", "Villa already exists");
                    return BadRequest(ModelState);
                }


                if (createDTO == null)
                {
                    return Ok(BadRequest(createDTO));
                }
                // villaDTO.Id = Villastore.Villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

                //Villastore.Villalist.Add(villaDTO);
                Villa model = _mapper.Map<Villa>(createDTO);
                //Villa model = new()
                //{
                //  Name = createDTO.Name,
                //Details = createDTO.Details,
                //Rate = createDTO.Rate,
                //Sqft = createDTO.Sqft,
                //Occupancy = createDTO.Occupancy,
                //ImageUrl = createDTO.ImageUrl,
                //Amenity = createDTO.Amenity
                //};
                await _dbvilla.CreateAsync(model);

                //var model1 = _mapper.Map<VillaDTO>(model);
                _response.Result = _mapper.Map<VillaDTO>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVilla", new { id = model.Id }, _response);
            }
            catch (Exception ex)
>>>>>>> Stashed changes
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

<<<<<<< Updated upstream

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
=======
            return _response;
>>>>>>> Stashed changes
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0)
                    return StatusCode(StatusCodes.Status400BadRequest);
                Villa villa = await _dbvilla.GetAsync(u => u.Id == id);
                if (villa == null)
                    return StatusCode(StatusCodes.Status404NotFound);
                await _dbvilla.RemoveAsync(villa);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

            return _response;
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody] VillaUpdateDTO updateDTO)
        {
            try
            {
                if (id == 0 || (updateDTO.Id != id))
                    return StatusCode(StatusCodes.Status400BadRequest);
                var villa = await _dbvilla.GetAsync(u => u.Id == id, tracked: false);
                if (villa == null)
                    return StatusCode(StatusCodes.Status404NotFound);
                var model = _mapper.Map<Villa>(updateDTO);
                //Villa model = new()
                //{
                //  Name = updateDTO.Name,
                //Id = updateDTO.Id,
                //Details = updateDTO.Details,
                //Rate = updateDTO.Rate,
                //Sqft = updateDTO.Sqft,
                //Occupancy = updateDTO.Occupancy,
                //ImageUrl = updateDTO.ImageUrl,
                //Amenity = updateDTO.Amenity
                //};
                await _dbvilla.UpdateAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

            return _response;

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        [HttpPatch("{id:int}", Name = "UpdatepartialVilla")]
        public async Task<ActionResult<APIResponse>> UpdatepartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            try
            {
                if (patchDTO == null || (id == 0))
                    return StatusCode(StatusCodes.Status400BadRequest);
                var villa = await _dbvilla.GetAsync(u => u.Id == id, tracked: false);
                if (villa == null)
                    return StatusCode(StatusCodes.Status404NotFound);
                var villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
                // VillaUpdateDTO villaDTO = new()
                //{
                //  Id = villa.Id,
                //Name = villa.Name,
                //Details = villa.Details,
                //Rate = villa.Rate,
                //Sqft = villa.Sqft,
                //Occupancy = villa.Occupancy,
                //ImageUrl = villa.ImageUrl,
                //Amenity = villa.Amenity

                // };
                patchDTO.ApplyTo(villaDTO, ModelState);
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                //Villa model = new()
                //{
                //  Id = villaDTO.Id,
                //Name = villaDTO.Name,
                //Details = villaDTO.Details,
                //Rate = villaDTO.Rate,
                //Sqft = villaDTO.Sqft,
                //Occupancy = villaDTO.Occupancy,
                //ImageUrl = villaDTO.ImageUrl,
                //Amenity = villaDTO.Amenity
                //};
                var model = _mapper.Map<Villa>(villaDTO);
                await _dbvilla.UpdateAsync(model);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
                return _response;
            }

            return _response;



        }

    }
}
