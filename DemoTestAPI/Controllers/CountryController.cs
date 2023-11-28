using DemoTestAPI.DataAccess.Entity;
using DemoTestAPI.DataAccess.UnitOfWork;
using DemoTestAPI.Models.Common;
using DemoTestAPI.Models.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region AddCountry

        [HttpPost("AddCountry")]
        public async Task<Status> AddCountry(CountryVM country)
        {
            Status s = new Status();

            Country Addcountry = new()
            {
                CountryCode = country.CountryCode,
                CountryName = country.CountryName,
                CreatedDate=DateTime.Now
            };
            var AddCountry = await _unitOfWork.countryRepository.AddCountry(Addcountry);
            s.statusCode = AddCountry.statusCode;
            s.message = AddCountry.message;
            return s;
        }

        #endregion AddEmployee

        #region DeleteCountry

        [HttpDelete("DeleteCountry")]
        public async Task<Status> DeleteCountry(int Id)
        {
            Status s = new Status();
            var CountryExists = await _unitOfWork.countryRepository.GetCountrybyid(Id);
            if (CountryExists != null)
            {
                var DeleteCountry = await _unitOfWork.countryRepository.DeleteCountry(CountryExists);
                s.message = DeleteCountry.message;
                s.statusCode = DeleteCountry.statusCode;
            }
            return s;
        }

        #endregion 

        #region UpdateCountry

        [HttpPut("UpdateCountry")]
        public async Task<Status> UpdateCountry(Country country)
        {
            Status s = new Status();
            var CountryExists = await _unitOfWork.countryRepository.GetCountrybyid(country.CountryId);
            if (CountryExists != null)
            {
                CountryExists.CountryName = country.CountryName;
                CountryExists.CountryCode = country.CountryCode;
                CountryExists.ModifiedDate = DateTime.Now;

                var UpdateCountry = await _unitOfWork.countryRepository.UpdateCountry(CountryExists);
                s.message = UpdateCountry.message;
                s.statusCode = UpdateCountry.statusCode;
            }
            return s;

        }

        #endregion UpdateEmployee

        #region GetAllCountry
        [HttpGet("GetAllCountry")]
        public async Task<List<Country>> GetAllCountry()
        {
            var getAllCountry = await _unitOfWork.countryRepository.GetAllCountry();
            return getAllCountry;
        }

        #endregion GetAlCountry

        #region GetCountryById

        [HttpGet("GetCountryById")]
        public async Task<Country> GetCountryById(int Id)
        {
            var GetCountryById = await _unitOfWork.countryRepository.GetCountrybyid(Id);
            return GetCountryById;
        }

        #endregion
    }
}
