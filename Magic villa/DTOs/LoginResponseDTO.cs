using Magic_villa.Models;

namespace Magic_villa.DTOs
{
    public class LoginResponseDTO
    {
        public LocalUser LocalUser { get; set; }
        public string Token { get; set; }
    }
}
