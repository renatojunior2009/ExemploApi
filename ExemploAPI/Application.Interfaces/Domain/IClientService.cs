using Application.Interfaces.Base;
using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Domain
{
    public interface IClientService : IServiceBase<Client>
    {
        Task<IEnumerable<Client>> GetSpecialsCustomers();
    }
}
