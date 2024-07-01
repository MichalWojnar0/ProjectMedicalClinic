namespace ProjectMedicalClinic.Models
{
    public class RoomsRepository
    {
        private static List<Room> _rooms = new List<Room>()
        {
            new Room { RoomId = 1, PatientId = 1, Name = "Room A", Floor = "First" },
            new Room { RoomId = 2, PatientId = 2, Name = "Room B", Floor = "Second" },
            new Room { RoomId = 3, PatientId = null, Name = "Room C", Floor = "Third" }
        };

        public static void AddRoom(Room room)
        {
            var maxId = _rooms.Max(x => x.RoomId);
            room.RoomId = maxId + 1;
            _rooms.Add(room);
            //This how this function should look like, this way we can add new room even if the list is empty, but due to Visual Studio bug it doesn't work.
            /*if (_rooms != null && _rooms.Count > 0)
            {
                var maxId = _rooms.Max(x => x.RoomId);
                room.RoomId = maxId + 1;
            }
            else
            {
                room.RoomId = 1;
            }
            if (_rooms == null) _rooms = new List<Room>();
            _rooms.Add(room);*/
        }

        public static List<Room> GetRooms(bool loadPatient = false)
        {
            if (!loadPatient)
            {
                return _rooms;
            }
            else
            {
                if (_rooms != null && _rooms.Count > 0)
                {
                    _rooms.ForEach(x =>
                    {
                        if (x.PatientId.HasValue)
                            x.Patient = PatientsRepository.GetPatientById(x.PatientId.Value);
                    });
                }
            }
            return _rooms ?? new List<Room>();
        }

        public static Room? GetRoomById(int roomId, bool loadPatient = false)
        {
            var room = _rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (room != null)
            {
                var rom = new Room
                {
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Floor = room.Floor,
                    PatientId = room.PatientId,
                };

                if (loadPatient && rom.PatientId.HasValue)
                {
                    rom.Patient = PatientsRepository.GetPatientById(rom.PatientId.Value);
                }

                return rom;
            }
            return null;
        }

        public static void UpdateRoom(int roomId, Room room)
        {
            if (roomId != room.RoomId) return;

            var roomToUpdate = _rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (roomToUpdate != null)
            {
                roomToUpdate.Name = room.Name;
                roomToUpdate.Floor = room.Floor;
                roomToUpdate.PatientId = room.PatientId;
            }
        }

        public static void DeleteRoom(int roomId)
        {
            var room = _rooms.FirstOrDefault(x => x.RoomId == roomId);
            if (room != null)
            {
                _rooms.Remove(room);
            }
        }
    }
}
