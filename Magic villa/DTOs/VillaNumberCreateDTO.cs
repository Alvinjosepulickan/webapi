using System.ComponentModel.DataAnnotations;

namespace Magic_villa.DTOs
{
    public class VillaNumberCreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
        //public VillaDTO Villa { get; set; }
    }
}
