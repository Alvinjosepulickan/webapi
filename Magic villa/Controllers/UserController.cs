using AutoMapper;
using Magic_villa.DTOs;
using Magic_villa.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Magic_villa.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersionNeutral]
    public class UserController : ControllerBase
    {
        private readonly ILogger<VillaAPIController> _logger;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<VillaAPIController> logger, IMapper mapper, IUserRepository userRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        [HttpPost]
        [Route("registeruser")]
        public async Task<IActionResult> RegisterUser(RegistrationRequestDTO registrationRequestDTO)
        {
            if(_userRepository.IsUniqueUser(registrationRequestDTO.UserName))
            {
                var user =await _userRepository.RegisterUser(registrationRequestDTO);
                if(user !=null)
                {
                    return Ok(user);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequestDTO)
        {
            var response= await _userRepository.Login(loginRequestDTO);
            if (response == null || response.LocalUser == null || String.IsNullOrEmpty(response.Token))
                return BadRequest(new { Message = "Invalid UserName or Password" });
            return Ok(response);
        }
    }
}
