
using Microsoft.EntityFrameworkCore;
using MyDemoAPI.Entities;

namespace MyDemoAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
        : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }

    }
}