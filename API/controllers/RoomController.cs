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
        private readonly RoomManager _manager;

        public RoomController(RoomManager manager)
        {
            _manager = manager;
        }

        [HttpGet] //GET /api/rooms
        [Authorize]
        public async Task<IActionResult> GetRooms()
        {
            var rooms = _manager.GetRooms();
            return Ok(rooms);
        }
        
        [HttpPost] //POST /api/rooms
        [Authorize(Roles = "Facilities Manager")]
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto dto)
        {
                var result = new RoomRequest(dto.room);

                var room = _manager.CreateRoom(result);

                return Ok(result);
        }

        [HttpDelete] //DELETE /api/rooms
        [Authorize(Roles = "Facilities Manager")]
        public async Task<IActionResult> DeleteRoom([FromBody] DeleteRoomDto dto)
        {
                var result = new RoomRequest(dto.room);

                return Ok("Successfully Deleted Room");
        }

    }
} 