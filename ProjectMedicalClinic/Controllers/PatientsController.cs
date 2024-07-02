using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ProjectMedicalClinic.Models;

namespace ProjectMedicalClinic.Controllers
{
    public class PatientsController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var patients = PatientsRepository.GetPatients();
            return View(patients);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit"; 

            var patient = PatientsRepository.GetPatientById(id.HasValue ? id.Value : 0);
            return View(patient);
        }
        [HttpPost]
        public IActionResult Edit(Patient patient)
        {
            if (ModelState.IsValid)
            {
                PatientsRepository.UpdatePatient(patient.PatientId, patient);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "edit";
            return View(patient);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";

            return View();
        }

        [HttpPost]
        public IActionResult Add(Patient patient)
        {
            if (ModelState.IsValid)
            {
                PatientsRepository.AddPatient(patient);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Action = "add";
            return View(patient);
        }

        public IActionResult Delete(int patientId) 
        {
            PatientsRepository.DeletePatient(patientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
