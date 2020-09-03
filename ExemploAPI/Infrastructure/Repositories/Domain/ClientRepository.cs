﻿using Domain;
using Infrastructure.Interfaces.Repositories.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Domain
{
    public class ClientRepository : DomainRepository<Client>, IClientRepository
    {
        #region Constructor
        public ClientRepository(DbContext dbContext) : base(dbContext) { }
        #endregion

        #region Publics Methods
        public async Task<IEnumerable> GetSpecialsCustomers()
        {
            IQueryable<Client> query = await Task.FromResult(GenerateQuery(conditions: c => c.Especial == true, hasOrdination: c => c.OrderBy(x => x.Nome)));

            return query.AsEnumerable();
        } 
        #endregion

    }
}