using AutoMapper;
using Magic_villa.DbContexts;
using Magic_villa.DTOs;
using Magic_villa.Models;
using Magic_villa.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Magic_villa.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    [ApiVersion("1.0",Deprecated =true)]
    [ApiVersion("2.0")]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IMagicVillaRepository _magicVillaRepository;
        private APIResponse apiResponse;
        public VillaAPIController(ILogger<VillaAPIController> logger,MagicVillaDbContext context, IMapper mapper, IMagicVillaRepository magicVillaRepository)
        {
            apiResponse = new APIResponse();
            _logger = logger;
            _magicVillaRepository = magicVillaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetVillas()
        {
            //_logger.LogError(StaticClass.villa.ToString());
            //apiResponse=new APIResponse()
            //{
            //    IsSuccess=true,
            //    Result= await _magicVillaRepository.GetAll(),
            //    StatusCode=HttpStatusCode.OK
            //};
            //return Ok(apiResponse);
            return Ok(await _magicVillaRepository.GetAll());
        }
        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetVilla()
        {
            //_logger.LogError(StaticClass.villa.ToString());
            //apiResponse=new APIResponse()
            //{
            //    IsSuccess=true,
            //    Result= await _magicVillaRepository.GetAll(),
            //    StatusCode=HttpStatusCode.OK
            //};
            //return Ok(apiResponse);
            return Ok();
        }
        [HttpGet]
        [Route("{id}")]
        //[ProducesResponseType(200,Type =typeof(Villa))]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        public async Task<IActionResult> GetVillaById([FromRoute] int id)
        {
            if(id<=0)
            {
                //apiResponse
                return BadRequest();
            }
            var villas =await _magicVillaRepository.Get(x => x.Id == id);
            if(villas==null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDTO>(villas));
        }
        [HttpPost]
        public async Task<IActionResult> SaveVilla([FromBody] VillaCreateDTO villaCreateObj)
        {
            var villa = _mapper.Map<Villa>(villaCreateObj);
            await _magicVillaRepository.Create(villa);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateVilla([FromBody] VillaDTO villaUpdateObj)
        {
            var villa = _mapper.Map<Villa>(villaUpdateObj);
            return Ok(_magicVillaRepository.Update(villa));
        }

        [HttpDelete]
        [Route("{id}")]
        public async  Task<IActionResult> DeleteVilla([FromRoute] int id)
        {
            var villa =await _magicVillaRepository.Get(x => x.Id == id);
            if (villa != null && villa.Id > 0)
            {
                _magicVillaRepository.Remove(villa);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch]
        public async Task<IActionResult> PatchVilla(int id, [FromBody] JsonPatchDocument<VillaUpdateDTO> villaDto)
        {
            if (villaDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = _magicVillaRepository.Get(x => x.Id == id,tracked:false);
            if(villa== null)
            {
                return BadRequest();
            }
            var villaObj = _mapper.Map<VillaUpdateDTO>(villa);
            villaDto.ApplyTo(villaObj, ModelState);
            Villa model = _mapper.Map<Villa>(villaDto);
            await _magicVillaRepository.Update(model);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok();

        }
    }
}
