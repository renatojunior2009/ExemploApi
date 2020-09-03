using Application.Base;
using Application.Interfaces.Domain;
using Domain;
using Infrastructure.Interfaces.Repositories.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Domain
{
    public class ClientService: ServiceBase<Client>, IClientService
    {
        private readonly IClientRepository _repository;
        public ClientService(IClientRepository repository):base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Client>> GetSpecialsCustomers()
        {
            return await _repository.GetSpecialsCustomers();
        }

        
    }
}
