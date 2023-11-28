using DemoTestAPI.DataAccess.Data;
using DemoTestAPI.DataAccess.Entity;
using DemoTestAPI.DataAccess.Repository.IRepository;
using DemoTestAPI.Models.Common;
using DemoTestAPI.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoTestAPI.DataAccess.Repository
{
    public class StateRepository : IStateRepository
    {
        public readonly ApplicationContext _db;
        public StateRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task<Status> AddState(StateVM state)
        {
            Status s = new Status();
            try
            {
                State stateData = new State()
                {
                    StateCode = state.StateCode,
                    StateName = state.StateName,
                    CountryID = state.CountryID
                };
                _db.states.Add(stateData);
                await _db.SaveChangesAsync();
                s.message = "State Added Successfully!";
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

        public async Task<List<State>> GetAllState()
        {
            var res = await _db.states.Include("country").ToListAsync();
            return res;
        }

        public async Task<State> GetStatebyid(int? id)
        {
            var res = await _db.states.FindAsync(id);
            return res;
        }

        public async Task<Status> UpdateState(State state)
        {
            Status s = new();
            _db.states.Update(state);
            await _db.SaveChangesAsync();
            s.message = "State Updated Successfully";
            s.statusCode = 1;
            return s;
        }
        public async Task<Status> DeleteState(State state)
        {
            Status s = new();
            _db.states.Remove(state);
            await _db.SaveChangesAsync();
            s.message = "State Deleted Successfully";
            s.statusCode = 1;
            return s;
        }
    }
}
