using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Models;

namespace RestWithAspNet10.Data.Context
{
    public class MsSqlContext : DbContext
    {
        public MsSqlContext (DbContextOptions<MsSqlContext> options) : base(options) { }

        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }
}
