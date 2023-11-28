using DemoTestAPI.DataAccess.Repository.IRepository;

namespace DemoTestAPI.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICountryRepository countryRepository { get; }
        IStateRepository stateRepository { get; }
    }
}
