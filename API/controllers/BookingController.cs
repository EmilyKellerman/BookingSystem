using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult> GetAll()
        {
            var bookings = await _manager.GetBookings();
            return Ok(calculations);
        }
        
        // [HttpPost]
        // public async Task<IActionResult> Calculate(CalculationRequest request)
        // {
        //     var result = await _calculator.CalculateAsync(request);
        //     return Ok(request);
        // }

    }
}