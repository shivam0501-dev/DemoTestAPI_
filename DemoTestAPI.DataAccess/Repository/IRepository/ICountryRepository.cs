using DemoTestAPI.DataAccess.Entity;
using DemoTestAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestAPI.DataAccess.Repository.IRepository
{
    public interface ICountryRepository
    {
        Task<Status> AddCountry(Country country);

        Task<List<Country>> GetAllCountry();

        Task<Country> GetCountrybyid(int id);
        Task<Status> UpdateCountry(Country country);

        Task<Status> DeleteCountry(Country country);
    }
}
