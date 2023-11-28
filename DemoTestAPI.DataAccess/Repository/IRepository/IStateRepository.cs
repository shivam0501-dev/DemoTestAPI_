using DemoTestAPI.DataAccess.Entity;
using DemoTestAPI.Models.Common;
using DemoTestAPI.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestAPI.DataAccess.Repository.IRepository
{
    public interface IStateRepository
    {
        Task<Status> DeleteState(State state);
        Task<Status> UpdateState(State state);
        Task<State> GetStatebyid(int? id);
        Task<List<State>> GetAllState();
        Task<Status> AddState(StateVM state);
    }
}
