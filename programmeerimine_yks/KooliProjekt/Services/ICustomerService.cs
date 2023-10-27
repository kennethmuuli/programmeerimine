using KooliProjekt.Data;
using KooliProjekt.Models;

namespace KooliProjekt.Services
{
    public interface ICustomerService
    {
        Task<PagedResult<Customer>> List(int page, int pageSize);
        Task<Customer> GetById(int id);
        Task Save(Customer Customer);
        Task Delete(int id);
    }
}
