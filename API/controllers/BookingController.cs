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
            return Ok(bookings);
        }
        
        [HttpPost] //POST /api/bookings
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            var result = new BookingRequest(dto.room, dto.startTime, dto.endTime);

            var booking = _manager.CreateBooking(result);
            return Ok(result + "\nBooking created successfully");
        }

    }
} 