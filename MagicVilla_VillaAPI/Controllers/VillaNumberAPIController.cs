using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.VillaDTO;
using MagicVilla_VillaAPI.Models.VillaNumberDTO;
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
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
        private readonly IVillaNumberRepository _dbvillanumber;
        private readonly IVillarepository _dbvilla;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        public VillaNumberAPIController(IVillaNumberRepository dbvillanumber, IMapper mapper,IVillarepository dbvilla)
        {
            _dbvillanumber = dbvillanumber;
            _mapper = mapper;
            this._response = new();
            _dbvilla = dbvilla;
        }


        
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {

                IEnumerable<VillaNumber> villanumberlist = await _dbvillanumber.GetAllAsync();
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villanumberlist);
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

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {

                if (id == 0)
                {

                    return BadRequest();
                }
                var villanumber = await _dbvillanumber.GetAsync(u => u.VillaNo == id);
                if (villanumber == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<VillaNumberDTO>(villanumber);
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
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody] VillaNumberCreateDTO createDTO)
        {
            try
            {
                //if(!ModelState.IsValid)
                //return BadRequest();
               // if (await _dbvillanumber.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                //{
                  //  ModelState.AddModelError("Custom Error", "Villa already exists");
                    //return BadR
                    //equest(ModelState);
                //}


                if (createDTO == null)
                {
                    return Ok(BadRequest(createDTO));
                }
                if(await _dbvilla.GetAsync(u=>u.Id==createDTO.VillaID)==null)
                {
                    ModelState.AddModelError("Custom Error", "Invalid Villa ID");
                    return BadRequest(ModelState);

                }

                // villaDTO.Id = Villastore.Villalist.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;

                //Villastore.Villalist.Add(villaDTO);
                VillaNumber model = _mapper.Map<VillaNumber>(createDTO);
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
                await _dbvillanumber.CreateAsync(model);

                //var model1 = _mapper.Map<VillaDTO>(model);
                _response.Result = _mapper.Map<VillaNumberDTO>(model);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaNumber", new { id = model.VillaNo }, _response);
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

        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                    return StatusCode(StatusCodes.Status400BadRequest);
                VillaNumber villanumber = await _dbvillanumber.GetAsync(u => u.VillaNo == id);
                if (villanumber == null)
                    return StatusCode(StatusCodes.Status404NotFound);
                await _dbvillanumber.RemoveAsync(villanumber);
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

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if (id == 0 || (updateDTO.VillaNo!= id))
                    return StatusCode(StatusCodes.Status400BadRequest);
                if (await _dbvilla.GetAsync(u => u.Id == updateDTO.VillaID) == null)
                {
                    ModelState.AddModelError("Custom Error", "Invalid Villa ID");
                    return BadRequest(ModelState);
                }
                var villanumber = await _dbvillanumber.GetAsync(u => u.VillaNo == id,tracked:false);
                if (villanumber == null)
                    return StatusCode(StatusCodes.Status404NotFound);
              
                var model = _mapper.Map<VillaNumber>(updateDTO);
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
                await _dbvillanumber.UpdateAsync(model);
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
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status200OK)]

        //[HttpPatch("{id:int}", Name = "UpdatepartialVilla")]
        //public async Task<ActionResult<APIResponse>> UpdatepartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        //{
        //    try
        //    {
        //        if (patchDTO == null || (id == 0))
        //            return StatusCode(StatusCodes.Status400BadRequest);
        //        var villa = await _dbvilla.GetAsync(u => u.Id == id, tracked: false);
        //        if (villa == null)
        //            return StatusCode(StatusCodes.Status404NotFound);
        //        var villaDTO = _mapper.Map<VillaUpdateDTO>(villa);
        //        // VillaUpdateDTO villaDTO = new()
        //        //{
        //        //  Id = villa.Id,
        //        //Name = villa.Name,
        //        //Details = villa.Details,
        //        //Rate = villa.Rate,
        //        //Sqft = villa.Sqft,
        //        //Occupancy = villa.Occupancy,
        //        //ImageUrl = villa.ImageUrl,
        //        //Amenity = villa.Amenity

        //        // };
        //        patchDTO.ApplyTo(villaDTO, ModelState);
        //        if (!ModelState.IsValid)
        //            return BadRequest(ModelState);
        //        //Villa model = new()
        //        //{
        //        //  Id = villaDTO.Id,
        //        //Name = villaDTO.Name,
        //        //Details = villaDTO.Details,
        //        //Rate = villaDTO.Rate,
        //        //Sqft = villaDTO.Sqft,
        //        //Occupancy = villaDTO.Occupancy,
        //        //ImageUrl = villaDTO.ImageUrl,
        //        //Amenity = villaDTO.Amenity
        //        //};
        //        var model = _mapper.Map<Villa>(villaDTO);
        //        await _dbvilla.UpdateAsync(model);
        //        _response.IsSuccess = true;
        //        _response.StatusCode = HttpStatusCode.OK;
        //        return _response;
        //    }
        //    catch (Exception ex)
        //    {
        //        _response.IsSuccess = false;
        //        _response.ErrorMessages = new List<string>() { ex.ToString() };
        //        return _response;
        //    }

        //    return _response;



        //}

    }
}
