using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    using Hospital.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    [ApiController]
    [Route("api/[controller]")]
    public class DonationController : ControllerBase
    {
        private readonly DonationDbContext _context;
        public DonationController(DonationDbContext context)
        {
            _context = context;
        }

        // -------------------- Task 1 --------------------

        // GET: api/donation/districts
        [HttpGet("districts")]
        public IActionResult GetDistricts()
        {
            var districts = _context.Districts
                .Select(d => new { d.DistrictId, d.DistrictName })
                .ToList();
            return Ok(districts);
        }

        // GET: api/donation/hospitals/{districtId}
        [HttpGet("hospitals/{districtId}")]
        public IActionResult GetHospitals(string districtId)
        {
            var hospitals = _context.Hospitals
                .Where(h => h.DistrictId == districtId)
                .Select(h => new { h.HospitalId, h.HospitalName })
                .ToList();
            return Ok(hospitals);
        }

        // POST: api/donation/add
        [HttpPost("add")]
        public async Task<IActionResult> AddDonations([FromBody] List<Donation> donations)
        {
            if (donations == null || donations.Count == 0)
                return BadRequest(new { message = "No donations provided." });

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Validation failed.", errors = ModelState });

            donations.ForEach(d => d.DonationId = 0);

            try
            {
                _context.Donations.AddRange(donations);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Donations added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Failed to save donations.", detail = ex.Message });
            }
        }
    }
}