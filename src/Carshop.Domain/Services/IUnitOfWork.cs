using System.Threading.Tasks;

namespace CarShop.Domain.Services
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
