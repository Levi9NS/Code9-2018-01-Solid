using AspNetApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
