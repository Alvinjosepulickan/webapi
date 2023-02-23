using Magic_villa.DTOs;

namespace Magic_villa
{
    public static class StaticClass
    {
        public static List<VillaDTO> villa = new List<VillaDTO>()
        {
            new VillaDTO()
            {
                Id=1,
                Name="Balinova"
            },
            new VillaDTO() {
                Id=2,
                Name="SunRise"
            }
        };
    }
}
