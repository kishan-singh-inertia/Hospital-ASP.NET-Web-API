using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.Models
{
    public class Donation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DonationId { get; set; }

        [Required]
        // Foreign Key
        public string HospitalId { get; set; } = string.Empty;

        [Required]
        // Foreign Key
        public string DistrictId { get; set; } = string.Empty;

        [Required]
        public DateTime DonationDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DonationAmount { get; set; }

        public Hospital? Hospital { get; set; }
        public District? District { get; set; }
    }
}