using Domain;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories.Domain
{
    public interface IClientRepository : IDomainRepository<Client>
    {
        Task<IEnumerable<Client>> GetSpecialsCustomers();
    }
}
