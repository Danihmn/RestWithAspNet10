using Microsoft.EntityFrameworkCore;

namespace RestWithAspNet10.Models.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext (DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<PersonModel> Persons { get; set; }
    }
}
