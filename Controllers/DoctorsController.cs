using HospitalSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalSystem.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoctorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(
            string doctorName,
            string specialization,
            int page = 1)
        {
            var doctors = _context.Doctors.AsQueryable();

            // Filter by doctor name
            if (!string.IsNullOrEmpty(doctorName))
            {
                doctors = doctors.Where(d =>
                    d.Name.Contains(doctorName));
            }

            // Filter by specialization
            if (!string.IsNullOrEmpty(specialization))
            {
                doctors = doctors.Where(d =>
                    d.Specialization == specialization);
            }

            // Pagination
            int pageSize = 3;

            var totalDoctors = await doctors.CountAsync();

            var doctorList = await doctors
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages =
                (int)Math.Ceiling(totalDoctors / (double)pageSize);

            ViewBag.DoctorName = doctorName;
            ViewBag.Specialization = specialization;

            ViewBag.Specializations = await _context.Doctors
                .Select(d => d.Specialization)
                .Distinct()
                .ToListAsync();

            return View(doctorList);
        }
    }
}