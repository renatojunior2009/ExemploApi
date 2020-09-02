using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DBConfiguration.ContextEFCore
{
    public class Context : DbContext
    {
        #region Publics Properties 
        public DbSet<Client> Client { get; set; }
        #endregion

        #region Constructor
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }
        #endregion

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConnection.ConnectionConfiguration.GetConnectionString("DefaultConnection"));
            }
        } 
        #endregion
    }
}
