using Microsoft.AspNetCore.Mvc;
using BookingSystem;
using System.Collections.Generic;

namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly BookingManager _manager;

        public BookingController(BookingManager manager)
        {
            _manager = manager;
        }

        [HttpGet] //GET /api/bookings
        public async Task<IActionResult> GetAll()
        {
            var bookings = _manager.GetBookings();
            if (!bookings.Any())//if there aren't any bookings then return an error message
            {
                return NotFound("There are no bookings in the history");
            }
            return Ok(bookings);
        }
        
        [HttpPost] //POST /api/bookings
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new BookingRequest(dto.room, dto.startTime, dto.endTime);

                var booking = await _manager.CreateBooking(result);
                if (booking == null)
                {
                    return BadRequest("Invalid input");
                }

                return Ok(result);
            }
            
        }

    }
} 