using DoctorSystem.DataAccess;
using DoctorSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _db = new();
        public IActionResult Index()
        {
            var appointments = _db.Appointments.ToList();

            return View(appointments);
        }
        
        [HttpGet]
        public IActionResult Apoi(int id)
        {
            var doctor = _db.Doctors
             .FirstOrDefault(d => d.Id == id);
            if (doctor == null) return NotFound();



            return View(doctor);
        }
        [HttpPost]
        public IActionResult Apoi(int doctorId ,string patientName,DateTime appointmentDate,TimeSpan appointmentTime)
        {
            var doctor = _db.Doctors.Find(doctorId);

            if (doctor == null)
                return NotFound();
            if (appointmentDate.Date < DateTime.Today)
            {
                return Content("You cannot book an appointment in the past.");
            }

            if (appointmentDate.DayOfWeek == DayOfWeek.Friday ||
                appointmentDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return Content("Appointments are not available on Friday and Saturday.");
            }
            var exists = _db.Appointments.Any(a =>
              a.DoctorId == doctorId &&
              a.Date.Date == appointmentDate.Date &&
              a.Time == appointmentTime);

            if (exists)
            {
                return Content("This appointment is already booked.");
            }
            var appointment = new Appointment
            {
                PatientName = patientName,
                Date = appointmentDate,
                Time = appointmentTime,
                DoctorId = doctorId
            };

            _db.Appointments.Add(appointment);
            _db.SaveChanges();
            return RedirectToAction("Index");

        } 

    }
}
