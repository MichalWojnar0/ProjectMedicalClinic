using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMedicalClinic.Models;
using System.Linq;

namespace ProjectMedicalClinic.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        public IActionResult Index()
        {
            var appointments = AppointmentsRepository.GetAppointments();
            return View(appointments);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
            return View();
        }

        [HttpPost]
        public IActionResult Add(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                AppointmentsRepository.AddAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "add";
            return View(appointment);
        }

        public IActionResult Edit(int id)
        {
            var appointment = AppointmentsRepository.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewBag.Action = "edit";
            return View(appointment);
        }

        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                AppointmentsRepository.UpdateAppointment(appointment.AppId, appointment);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Action = "edit";
            return View(appointment);
        }
        public IActionResult Delete(int id)
        {
            AppointmentsRepository.DeleteAppointment(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
