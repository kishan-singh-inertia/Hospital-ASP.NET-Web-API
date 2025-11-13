using System.ComponentModel.DataAnnotations;

namespace Hospital.Models
{
    public class Hospital
    {
        [Key]
        public string HospitalId { get; set; } = string.Empty;

        [Required]
        public string HospitalName { get; set; } = string.Empty;

        // Foreign Key
        [Required]
        public string DistrictId { get; set; } = string.Empty;

        public District District { get; set; } = null!;

        public ICollection<Donation> Donations { get; set; } = new List<Donation>();
    }
}