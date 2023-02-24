using Magic_villa.DTOs;
using Magic_villa.Models;

namespace Magic_villa.Repository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string userName);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<LocalUser> RegisterUser(RegistrationRequestDTO registrationRequestDTO);
    }
}
