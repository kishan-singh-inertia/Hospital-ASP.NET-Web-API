using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class District
    {
        [Key]
        public string DistrictId { get; set; } = string.Empty;

        [Required]
        public string DistrictName { get; set; } = string.Empty;

        public ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();
    }
}