﻿using Domain;
using Infrastructure.Interfaces.Repositories.Domain;
using Infrastructure.Repositories.Base.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Client>> GetSpecialsCustomers()
        {
            IQueryable<Client> query = await Task.FromResult(GenerateQuery(c => c.Especial == true, c => c.OrderBy(x => x.Nome)));

            return query.AsEnumerable();
        } 
        #endregion

    }
}
