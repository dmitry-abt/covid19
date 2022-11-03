using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidWatch.Models;

namespace CovidWatch.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAll();
        Task<IEnumerable<Country>> GetBest();
        Task<IEnumerable<Country>> GetWorse();
    }
}