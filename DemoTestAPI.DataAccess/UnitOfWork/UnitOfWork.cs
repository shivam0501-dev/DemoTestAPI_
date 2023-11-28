using DemoTestAPI.DataAccess.Data;
using DemoTestAPI.DataAccess.Repository;
using DemoTestAPI.DataAccess.Repository.IRepository;

namespace DemoTestAPI.DataAccess.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationContext _db;
        public UnitOfWork(ApplicationContext db)
        {
            _db = db;
        }

        public ICountryRepository countryRepository => new CountryRepository(_db);
        public IStateRepository stateRepository => new StateRepository(_db);

    }
}
