using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Infrastructure.Data.Data.Context
{
    public partial class ApplicationDbContext : DbContext, IDBContext
    {
        public IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            while (true)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration["connection_string"]);
        }
    }
}
