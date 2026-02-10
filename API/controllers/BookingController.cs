using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using BookingSystem;
using System.Collections.Generic;

namespace API.controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly BookingManager _manager;//refrain from using for layered protection between classes
        private readonly EFBookingStore _context; //making more use of this

        public BookingController(BookingManager manager, EFBookingStore context)
        {
            _manager = manager;
            _context = context;
        }

        [HttpGet] //GET /api/bookings
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _context.LoadAllAsync();//implementing DB
            return Ok(bookings);
        }
        
        [HttpPost] //POST /api/bookings
        [Authorize(Roles = "Admin,Employee,Receptionist")]
        public async Task<IActionResult> Book([FromBody] CreateBookingDto dto)
        {
            var result = new BookingRequest(dto.room, dto.startTime, dto.endTime);

            var booking = await _context.SaveAsync(result);//implementing DB
            return Ok(result + "\nBooking created successfully");
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