using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectMedicalClinic.Models;
using ProjectMedicalClinic.ViewModels;

namespace ProjectMedicalClinic.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            var rooms = RoomsRepository.GetRooms(loadPatient: true);
            return View(rooms);
        }

        public IActionResult Add()
        {
            ViewBag.Action = "add";
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

            ViewBag.Action = "add";
            roomViewModel.Patients = PatientsRepository.GetPatients();
            return View(roomViewModel);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Action = "edit";
            var roomViewModel = new RoomViewModel
            {
                Room = RoomsRepository.GetRoomById(id) ?? new Room(),
                Patients = PatientsRepository.GetPatients()
            };

            return View(roomViewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel roomViewModel)
        {
            ViewBag.Action = "edit";
            if (ModelState.IsValid)
            {
                RoomsRepository.UpdateRoom(roomViewModel.Room.RoomId, roomViewModel.Room);
                return RedirectToAction(nameof(Index));
            }

            roomViewModel.Patients = PatientsRepository.GetPatients();

            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }

            return View(roomViewModel);
        }

        public IActionResult Delete(int id) 
        {
            RoomsRepository.DeleteRoom(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

