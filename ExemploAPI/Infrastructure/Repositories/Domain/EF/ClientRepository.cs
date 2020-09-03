using Domain;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Base.EF;
using Infrastructure.Repositories.Domain.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Domain.EF
{
    public class ClientRepository : DomainRepository<Client>, IClientRepository
    {
        #region Constructor
        public ClientRepository(DbContext dbContext) : base(dbContext) { }
        #endregion

        #region Publics Methods
        public async Task<IEnumerable> GetSpecialsCustomers()
        {
            IQueryable<Client> query = await Task.FromResult(GenerateQuery(c => c.Especial == true, c => c.OrderBy(x => x.Nome)));

            return query.AsEnumerable();
        } 
        #endregion

    }
}
