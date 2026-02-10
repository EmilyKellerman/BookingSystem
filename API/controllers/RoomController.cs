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
        private readonly AppDbContext _db;
        private readonly RoomManager _manager;//refrain from using for security

        public RoomController(RoomManager manager, EFBookingStore context, AppDbContext db)
        {
            _manager = manager;
            _context = context;
            _db = db;
        }

        [HttpGet] //GET /api/rooms
        [Authorize]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = await _context.LoadRoomsAsync();
            return Ok(rooms);
        }
        
        [HttpPost] //POST /api/rooms
        [Authorize(Roles = "Facilities Manager")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto dto)
        {
            // dto.room is already a ConferenceRoom
            await _context.SaveRoomAsync(dto.room);
            return Ok(dto.room);
        }

        [HttpPatch] //PATCH /api/rooms
        [Authorize(Roles = "Facilities Manager, Admin")]
        public async Task<IActionResult> DeleteRoom([FromBody] DeleteRoomDto dto)
        {
            var room = dto.room;
            await _context.RemoveRoomAsync(room);
            return Ok("Successfully Deleted Room");
        }//changing delete to PATCH - merged

    }
} 