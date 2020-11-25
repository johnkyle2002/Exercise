
using Exercise.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exercise.Repository.DBContext
{
    public class PaymentDBContext : IdentityDbContext<ApplicationUser,ApplicationRole, string>
    {
        public PaymentDBContext(DbContextOptions<PaymentDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Payment> Payment { get; set; }
    }
}
