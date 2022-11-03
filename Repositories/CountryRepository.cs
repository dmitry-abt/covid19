using Microsoft.EntityFrameworkCore;
using CovidWatch.Models;
using CovidWatch.Data;
using Newtonsoft.Json;

namespace CovidWatch.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly IDataContext _context;

        public CountryRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            UploadData();
            return await _context.Countries.ToListAsync();
        }

        public async Task<IEnumerable<Country>> GetBest()
        {
            var q = _context.Countries
                .OrderBy(data => data.Deaths)
                .Take(10)
                .ToListAsync();

            return await q;
        }

        public async Task<IEnumerable<Country>> GetWorse()
        {
            var q = _context.Countries
                .OrderByDescending(data => data.Deaths)
                .Take(10)
                .ToListAsync();

            return await q;
        }

        public void UploadData()
        {
            var dataset = _context.Countries.ToList();
            if (dataset.Count() == 0)
            {
                Console.WriteLine("No Data");

                var geoJSON = File.ReadAllText("C:\\Users\\developer\\Downloads\\covid19_time_series.geojson");
                dynamic jsonObj = JsonConvert.DeserializeObject(geoJSON);
                foreach (var feature in jsonObj["features"])
                {
                    string iso = feature["properties"]["iso"];
                    string name = feature["properties"]["name"];
                    string confirmed = feature["properties"]["current_confirmed"];
                    string recovered = feature["properties"]["current_recovered"];
                    string deaths = feature["properties"]["current_deaths"];
                    string geometry = feature["geometry"]["coordinates"].ToString(Newtonsoft.Json.Formatting.None);
                    string type = feature["geometry"]["type"];

                    Country country = new()
                    {
                        Iso = iso,
                        Name = name,
                        Confirmed = Convert.ToInt32(confirmed),
                        Recovered = Convert.ToInt32(recovered),
                        Deaths = Convert.ToInt32(deaths),
                        Coordinates = geometry,
                        Type = type
                    };

                    _context.Countries.Add(country);
                    _context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Data Loaded");
            }
        }
    }
}