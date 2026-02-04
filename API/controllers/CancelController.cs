using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CancelBooking([FromBody] CancelBookingDto dto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = new BookingRequest(dto.room, dto.startTime, dto.endTime);

                if (!_manager.CancelBooking(result))
                {
                    return BadRequest("Invalid input. Cancellation failed.");
                }

                return Ok("Successfully cancelled the booking");
            }//already have explicit failure responses
        }

    }
}
