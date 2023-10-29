using KooliProjekt.Data;
using KooliProjekt.Models;

namespace KooliProjekt.Services
{
    public interface IVehicleTypeService
    {
        Task<PagedResult<VehicleType>> List(int page, int pageSize);
        Task<VehicleType> GetById(int id);
        Task Save(VehicleType vehicleType);
        Task Delete(int id);
        bool VehicleTypeExists(int id);
    }
}
