using Microsoft.AspNetCore.Mvc;
using ProjectMedicalClinic.Models;
using ProjectMedicalClinic.ViewModels;

namespace ProjectMedicalClinic.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            var rooms = RoomsRepository.GetRooms(loadPatient: true);
            return View(rooms);
        }

        public IActionResult Add()
        {
            var roomViewModel = new RoomViewModel
            {
                Patients = PatientsRepository.GetPatients()
            };

            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult Add(RoomViewModel roomViewModel)
        {
            if (ModelState.IsValid) 
            {
                RoomsRepository.AddRoom(roomViewModel.Room);
                return RedirectToAction(nameof(Index));
            }
            roomViewModel.Patients = PatientsRepository.GetPatients();
            return View(roomViewModel);
        }
    }
}
