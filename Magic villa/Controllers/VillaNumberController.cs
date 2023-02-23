using AutoMapper;
using Magic_villa.DTOs;
using Magic_villa.Models;
using Magic_villa.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Magic_villa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaNumberController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IVillaNumberRepository _magicVillaRepository;
        private APIResponse apiResponse;

        public VillaNumberController(ILogger<VillaAPIController> logger, IMapper mapper, IVillaNumberRepository magicVillaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _magicVillaRepository = magicVillaRepository;
            this.apiResponse = new APIResponse();
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _magicVillaRepository.Get(x => x.VillNo == id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _magicVillaRepository.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VillaNumberCreateDTO villaCreateDTO)
        {
            var villa = _mapper.Map<VillaNumber>(villaCreateDTO);
            await _magicVillaRepository.Create(villa);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] VillaNumberUpdateDTO villaUpdateDTO)
        {
            var villa = _mapper.Map<VillaNumber>(villaUpdateDTO);
            await _magicVillaRepository.Create(villa);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var villa = await _magicVillaRepository.Get(x => x.VillNo == id);
            if (villa != null && villa.VillNo > 0)
            {
                _magicVillaRepository.Remove(villa);
                return Ok(await _magicVillaRepository.GetAll());
            }
            else
            {
                return NotFound();
            }
        }
    }
}
