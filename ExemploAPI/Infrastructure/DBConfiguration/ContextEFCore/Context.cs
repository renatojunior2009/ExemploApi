using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBConfiguration.ContextEFCore
{
    public class Context : DbContext
    {
        #region Publics Properties 
        public DbSet<Client> Client { get; set; } 
        #endregion

        #region Constructor
        public Context(DbContextOptions<Context> options) : base(options) { } 
        #endregion
    }
}
