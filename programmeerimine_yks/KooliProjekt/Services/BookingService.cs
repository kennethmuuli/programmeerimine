using KooliProjekt.Data;
using KooliProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class BookingService
    {
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Booking>> List(int page, int pageSize)
        {
            var result = await _context.Bookings.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Booking> GetById(int id)
        {
            var result = await _context.Bookings.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Booking Booking)
        {
            if (Booking.Id == 0)
            {
                _context.Add(Booking);
            }
            else
            {
                _context.Update(Booking);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Booking = await _context.Bookings.FindAsync(id);
            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
            }

            await _context.SaveChangesAsync();
        }
    }
}
