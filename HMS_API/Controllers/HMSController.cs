using HMS_BusinessLogic;
using HMS_DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_API.Controllers
{
    [Route("api/HMS")]
    [ApiController]
    public class HMSController : ControllerBase
    {
        [HttpGet("RoomTypes", Name = "GetAllRoomsTypes")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<DTORoomType>> GetAllRoomsType()
        {
            var bookings = clsRoomTypes.GetAllRoomsTypeDTO();

            if (bookings.Count == 0)
            {
                return NotFound("No Room Type found");
            }

            return Ok(bookings);
        }

        [HttpGet("Bookings", Name = "GetAllBookingsTypes")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]


        public ActionResult<IEnumerable<BookingsDTO>> GetAllBookings()
        {
            var bookings = clsBookings.GetAllBookings();

            if (bookings.Count == 0)
            {
                return NotFound("No Bookings found");
            }

            return Ok(bookings);
        }
    }
}
