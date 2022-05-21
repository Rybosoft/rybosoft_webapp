using Microsoft.EntityFrameworkCore;

namespace rybosoft_webapp.Models
{
    public class RyboDBContext : DbContext
    {
        public RyboDBContext() : base() {}

        // Only for Program.cs implementation
        //public RyboDBContext(DbContextOptions<RyboDBContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Messages>? Messages { get; set; }
    }
}
