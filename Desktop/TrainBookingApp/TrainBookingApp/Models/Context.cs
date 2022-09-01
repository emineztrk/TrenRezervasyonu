using Microsoft.EntityFrameworkCore;

namespace TrainBookingApp.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }
        public DbSet<Tren> Trens { get; set; } = null!;
    }
}
