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
        public ActionResult<IEnumerable<Booking>> GetAll()
        {
            var bookings = _manager.GetBookings();
            return Ok(bookings);
        }
        
        [HttpPost] //POST /api/bookings
        public ActionResult<Booking> Book([FromBody] BookingRequest request)
        {
            var result = _manager.CreateBooking(request);
            return Ok(result);
        }

    }
} 