using KooliProjekt.Data;
using KooliProjekt.Models;

namespace KooliProjekt.Services
{
    public interface IVehicleService
    {
        Task<PagedResult<Vehicle>> List(int page, int pageSize);
        Task<Vehicle> GetById(int id);
        Task Save(Vehicle Vehicle);
        Task Delete(int id);
    }
}
