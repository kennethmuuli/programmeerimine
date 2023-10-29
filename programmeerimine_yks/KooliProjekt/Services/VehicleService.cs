using KooliProjekt.Data;
using KooliProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext _context;

        public VehicleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Vehicle>> List(int page, int pageSize)
        {
            var result = await _context.Vehicles.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<Vehicle> GetById(int id)
        {
            var result = await _context.Vehicles.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(Vehicle Vehicle)
        {
            if (Vehicle.Id == 0)
            {
                _context.Add(Vehicle);
            }
            else
            {
                _context.Update(Vehicle);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var Vehicle = await _context.Vehicles.FindAsync(id);
            if (Vehicle != null)
            {
                _context.Vehicles.Remove(Vehicle);
            }

            await _context.SaveChangesAsync();
        }

        public bool VehicleExists (int id)
        {
            return (_context.Vehicles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
    
}
