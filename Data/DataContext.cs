using Microsoft.EntityFrameworkCore;
using CovidWatch.Models;

namespace CovidWatch.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }

        public DbSet<Country> Countries { get; set; }
    }
}