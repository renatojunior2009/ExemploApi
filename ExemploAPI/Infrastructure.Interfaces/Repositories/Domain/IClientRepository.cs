using Domain;
using System.Collections;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories.Domain
{
    public interface IClientRepository : IDomainRepository<Client>
    {
        Task<IEnumerable> GetSpecialsCustomers();
    }
}
