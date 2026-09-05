using DoctorSystem.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoctorSystem.Controllers
{

    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _db = new();

        public IActionResult Index(string? specialization)
        {
            var doctors = _db.Doctors
             .Include(d => d.Specialization)
             .AsQueryable();

            if (!string.IsNullOrEmpty(specialization))
            {
                doctors = doctors.Where(d =>d.Specialization.Name.Contains(specialization));
            }

            var result = doctors
                .Take(9)
                .ToList();


            return View(result);
        }
    }
}
