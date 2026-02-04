using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetRooms()
        {
            var rooms = _manager.GetRooms();
            if (!rooms.Any())//if there aren't any rooms then return an error message
            {
                return NotFound("There are no rooms yet");
            }
            return Ok(rooms);
        }
        
        [HttpPost] //POST /api/rooms
        public async Task<IActionResult> CreateRoom([FromBody] CreateRoomDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new RoomRequest(dto.room);

                var room = _manager.CreateRoom(result);
                if (room == null)
                {
                    return BadRequest("Invalid input");
                }

                return Ok(result);
            }
            
        }

        [HttpDelete] //DELETE /api/rooms
        public async Task<IActionResult> DeleteRoom([FromBody] DeleteRoomDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new RoomRequest(dto.room);

                if (!_manager.DeleteRoom(result))
                {
                    return BadRequest("Invalid input");
                }

                return Ok("Successfully deleted room");
            }
        }

    }
} 