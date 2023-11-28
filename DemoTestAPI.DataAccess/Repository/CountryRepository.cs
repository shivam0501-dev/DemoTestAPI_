using DemoTestAPI.DataAccess.Data;
using DemoTestAPI.DataAccess.Entity;
using DemoTestAPI.DataAccess.Repository.IRepository;
using DemoTestAPI.Models.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DemoTestAPI.DataAccess.Repository
{
    public class CountryRepository : ICountryRepository
    {
        public readonly ApplicationContext _db;
        public CountryRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Status> AddCountry(Country country)
        {
            Status s = new Status();
            try
            {
                Country countryData = new Country()
                {
                    CountryCode = country.CountryCode,
                    CountryName = country.CountryName,
                };
                _db.countries.Add(countryData);
                await _db.SaveChangesAsync();
                s.message = "Country Added Successfully!";
                s.statusCode = 1;
                return s;
            }
            catch (Exception ex)
            {
                s.message = ex.Message;
                s.statusCode = 0;
                return s;
            }
        }

        public async Task<List<Country>> GetAllCountry()
        {
            var res = await _db.countries.ToListAsync();
            return res;
        }

        public async Task<Country> GetCountrybyid(int id)
        {
            var res = await _db.countries.FindAsync(id);
            return res;
        }

        public async Task<Status> UpdateCountry(Country country)
        {
            Status s = new();
            _db.countries.Update(country);
            await _db.SaveChangesAsync();
            s.message = "Country Updated Successfully";
            s.statusCode = 1;
            return s;
        }
        public async Task<Status> DeleteCountry(Country country)
        {
            Status s = new();
            _db.countries.Remove(country);
            await _db.SaveChangesAsync();
            s.message = "Country Deleted Successfully";
            s.statusCode = 1;
            return s;
        }
    }
}
