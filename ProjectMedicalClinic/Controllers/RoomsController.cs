using Microsoft.AspNetCore.Mvc;
using ProjectMedicalClinic.Models;

namespace ProjectMedicalClinic.Controllers
{
    public class RoomsController : Controller
    {
        public IActionResult Index()
        {
            var rooms = RoomsRepository.GetRooms(loadPatient: true);
            return View(rooms);
        }
    }
}
