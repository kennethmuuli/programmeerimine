using KooliProjekt.Data;
using KooliProjekt.Models;

namespace KooliProjekt.Services
{
    public interface IRentalService
    {
        Task<PagedResult<Rental>> List(int page, int pageSize);
        Task<Rental> GetById(int id);
        Task Save(Rental Rental);
        Task Delete(int id);
    }
}
