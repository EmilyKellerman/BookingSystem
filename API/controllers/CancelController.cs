using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingSystem;
using System.Collections.Generic;

namespace API.controllers
{
    [ApiController]
    [Route("api/cancel")]
    public class CancelController : ControllerBase
    {
        private readonly BookingManager _manager;

        public CancelController(BookingManager manager)
        {
            _manager = manager;
        }

        [HttpDelete] //DELETE /api/bookings
        [Authorize(Roles = "Employee,Receptionist")]
        public async Task<IActionResult> CancelBooking([FromBody] CancelBookingDto dto)
        {
                var result = new BookingRequest(dto.room, dto.startTime, dto.endTime);
                return Ok("Successfully cancelled the booking");
        }

    }
}
