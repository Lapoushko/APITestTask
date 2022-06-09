using Microsoft.EntityFrameworkCore;

namespace APITestTask.Model
{
    public class PersonalsContext : DbContext
    {
        public PersonalsContext(DbContextOptions<PersonalsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<PersonalAccount> PersonalAccount { get; set; }
        public DbSet<Personal> Personals { get; set; }        
    }
}
