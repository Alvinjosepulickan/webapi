using Magic_villa.DbContexts;
using Magic_villa.DTOs;
using Magic_villa.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Magic_villa.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MagicVillaDbContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(MagicVillaDbContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public bool IsUniqueUser(string userName)
        {
            if (_context.LocalUsers.Where(x => x.UserName == userName).ToList().Any())
                return false;
            return true;
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _context.LocalUsers.FirstOrDefault(x => x.UserName == loginRequestDTO.UserName && x.Password == loginRequestDTO.Password);
            var secretKey= _configuration.GetValue<string>("ApiSettings:Secret");
            if (user != null && !string.IsNullOrEmpty(user.UserName) && !string.IsNullOrEmpty(user.Password))
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secretKey);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim(ClaimTypes.Role, user.Role),
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var loginResponseDTO = new LoginResponseDTO()
                {
                    LocalUser = user,
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                };
                return loginResponseDTO;
            }
            return null;
        }

        public async Task<LocalUser> RegisterUser(RegistrationRequestDTO registrationRequestDTO)
        {
            LocalUser localUser = new LocalUser()
            {
                Name = registrationRequestDTO.Name,
                Password = registrationRequestDTO.Password,
                Role = registrationRequestDTO.Role,
                UserName = registrationRequestDTO.UserName
            };
            await _context.LocalUsers.AddAsync(localUser);
            await _context.SaveChangesAsync();
            localUser.Password = "";
            return localUser;
        }
    }
}
