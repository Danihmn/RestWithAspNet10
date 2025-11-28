using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Data.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext (DbContextOptions<MSSQLContext> options) : base(options) { }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
