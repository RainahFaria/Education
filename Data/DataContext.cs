using Microsoft.EntityFrameworkCore;
using Education.Models;

namespace Education.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {

        }

        public DbSet<School> Schools { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
    }
}
