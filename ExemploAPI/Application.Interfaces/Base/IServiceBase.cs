using System.Threading.Tasks;

namespace Application.Interfaces.Base
{
    public interface IServiceBase<T> where T: class
    {
        Task<T> SaveAsync(T entity);
    }
}
