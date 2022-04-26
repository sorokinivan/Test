using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface ITenderRepository
    {
        Task<IEnumerable<Tender>> GetTendersFromWebService();
    }
}
