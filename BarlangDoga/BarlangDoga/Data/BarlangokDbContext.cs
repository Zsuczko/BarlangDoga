using BarlangDoga.Models;
using Microsoft.EntityFrameworkCore;

namespace BarlangDoga.Data
{
    public class BarlangokDbContext: DbContext
    {
        public BarlangokDbContext(DbContextOptions options): base(options)
        {
            
        }


        public DbSet<Barlang> barlangok { get; set; }
    }
}
