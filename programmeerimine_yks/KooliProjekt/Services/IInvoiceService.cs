using KooliProjekt.Data;
using KooliProjekt.Models;

namespace KooliProjekt.Services
{
    public interface IInvoiceService
    {
        Task<PagedResult<Invoice>> List(int page, int pageSize);
        Task<Invoice> GetById(int id);
        Task Save(Invoice Invoice);
        Task Delete(int id);
        bool InvoiceExists(int id);
    }
}
