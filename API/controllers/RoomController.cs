using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingSystem;
using System.Collections.Generic;

namespace API.controllers
{
    [ApiController]
    [Route("api/rooms")]
    public class RoomController : ControllerBase
    {
        private readonly EFBookingStore _context;
        private readonly BookingDbContext _db;
        private readonly RoomManager _manager;//refrain from using for security

        public RoomController(RoomManager manager, EFBookingStore context, BookingDbContext db)
        {
            _manager = manager;
            _context = context;
            _db = db;
        }

        [HttpGet] //GET /api/rooms
        [Authorize]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = _context.LoadRoomsAsync();
            return Ok(rooms);
        }
        
        [HttpPost] //POST /api/rooms
        [Authorize(Roles = "Facilities Manager")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto dto)
        {
                var result = new RoomRequest(dto.room);

                var room = _context.SaveRoomAsync(result);

                return Ok(result);
        }

        [HttpPatch] //PATCH /api/rooms
        [Authorize(Roles = "Facilities Manager, Admin")]
        public async Task<IActionResult> DeleteRoom([FromBody] DeleteRoomDto dto)
        {
                var result = new RoomRequest(dto.room);
                var deletedRoom = await _context.RemoveRoomAsync(result);
                return Ok("Successfully Deleted Room");
        }//changing delete to PATCH - merged

    }
} 