using hoteldormebem.Data;
using hoteldormebem.Models;
using Microsoft.AspNetCore.Mvc;


namespace hoteldormebem.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly ApiContext _context;
            
        public HotelController (ApiContext context)
        {
            _context= context;
        }

        [HttpPost("/CreatEdit")]
        public JsonResult Createdit(HotelBooking Booking)
        {
            if (Booking.Id == 0)
            {
                _context.Bookings.Add(Booking);
            }
            else
            {
                var DB = _context.Bookings.Find(Booking.Id);
                if (DB == null)
                {
                    return new JsonResult(NotFound());
                }
                DB = Booking;
            }
                _context.SaveChanges();
            return new JsonResult(Booking);
        }

        [HttpGet("/GetReserva")]
        public JsonResult GetHotel(int id)
        {
            var result = _context.Bookings.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(result));
        }

        [HttpDelete("/DeleteHotel")]
        public JsonResult Delete(int id)
        {
            var result = _context.Bookings.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Bookings.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());

        }

        [HttpGet("/GetAll")]
        public JsonResult GetAll()
        {
            var result = _context.Bookings.ToList();
            return new JsonResult(Ok(result));
        }
    }
}
