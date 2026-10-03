using HospitalSystem.Data;
using HospitalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Book Appointment Page
        public async Task<IActionResult> Book(int doctorId)
        {
            var doctor = await _context.Doctors.FindAsync(doctorId);

            if (doctor == null)
            {
                return NotFound();
            }

            ViewBag.Doctor = doctor;

            return View();
        }

        // Save Appointment
        [HttpPost]
        public async Task<IActionResult> Book(Appointment appointment)
        {
            if (appointment.Date.DayOfWeek == DayOfWeek.Friday ||
                appointment.Date.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError(
                    "Date",
                    "Appointments are available only from Sunday to Thursday.");
            }

            bool alreadyBooked = await _context.Appointments.AnyAsync(a =>
                a.DoctorId == appointment.DoctorId &&
                a.Date.Date == appointment.Date.Date &&
                a.Time == appointment.Time);

            if (alreadyBooked)
            {
                ModelState.AddModelError(
                    "Time",
                    "This doctor is already booked at this time.");
            }

            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            var doctor = await _context.Doctors.FindAsync(appointment.DoctorId);

            ViewBag.Doctor = doctor;

            return View(appointment);
        }

        // View Appointments
        public async Task<IActionResult> Index()
        {
            var appointments = await _context.Appointments
                .Include(a => a.Doctor)
                .ToListAsync();

            return View(appointments);
        }
    }
}