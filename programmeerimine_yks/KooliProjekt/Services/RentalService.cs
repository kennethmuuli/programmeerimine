using KooliProjekt.Data;
using KooliProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class RentalService : IRentalService
    {
        private readonly ApplicationDbContext _context;

        public RentalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Rental>> List(int page, int pageSize)
        {
            var result = await _context.Rental.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Rental> GetById(int id)
        {
            var result = await _context.Rental.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Rental Rental)
        {
            if (Rental.Id == 0)
            {
                _context.Add(Rental);
            }
            else
            {
                _context.Update(Rental);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Rental = await _context.Rental.FindAsync(id);
            if (Rental != null)
            {
                _context.Rental.Remove(Rental);
            }

            await _context.SaveChangesAsync();
        }
    }
}
