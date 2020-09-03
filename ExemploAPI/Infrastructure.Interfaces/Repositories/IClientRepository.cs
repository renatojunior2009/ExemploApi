using Domain;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Collections;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface IClientRepository : IDomainRepository<Client>
    {
        Task<IEnumerable> GetSpecialsCustomers();
    }
}
