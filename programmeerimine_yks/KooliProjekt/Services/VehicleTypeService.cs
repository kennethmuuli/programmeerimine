using KooliProjekt.Data;
using KooliProjekt.Models;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly ApplicationDbContext _context;

        public VehicleTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<VehicleType>> List(int page, int pageSize)
        {
            var result = await _context.VehicleTypes.GetPagedAsync(page, pageSize);

            return result;
        }

        public async Task<VehicleType> GetById(int id)
        {
            var result = await _context.VehicleTypes.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }

        public async Task Save(VehicleType vehicleType)
        {
            if (vehicleType.Id == 0)
            {
                _context.Add(vehicleType);
            }
            else
            {
                _context.Update(vehicleType);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var VehicleType = await _context.VehicleTypes.FindAsync(id);
            if (VehicleType != null)
            {
                _context.VehicleTypes.Remove(VehicleType);
            }

            await _context.SaveChangesAsync();
        }

        public bool VehicleTypeExists (int id)
        {
            return (_context.VehicleTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}