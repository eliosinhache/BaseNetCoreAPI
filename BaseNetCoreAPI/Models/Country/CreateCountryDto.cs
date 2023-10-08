using System.ComponentModel.DataAnnotations;

namespace BaseNetCoreAPI.Models.Country
{
    public class CreateCountryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ShortName { get; set; }
    }
}
