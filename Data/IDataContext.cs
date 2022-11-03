using Microsoft.EntityFrameworkCore;
using CovidWatch.Models;

namespace CovidWatch.Data
{
    public interface IDataContext
    {
        DbSet<Country> Countries { get; set; }
        int SaveChanges();
    }
}