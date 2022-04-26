using WebService1.Models;

namespace WebService1.Repositories
{
    public interface ITenderRepository
    {
        Task<IEnumerable<Tender>> GetTendersFromXLS();
    }
}
