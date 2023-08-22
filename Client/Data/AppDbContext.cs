using Microsoft.EntityFrameworkCore;

namespace Client.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-OC1MMIB; Database=APICRUD_Client; Integrated Security=True; TrustServerCertificate=True; encrypt=false");
        }

        public DbSet <Clientes> _Clientes { get; set;}
    }
}
