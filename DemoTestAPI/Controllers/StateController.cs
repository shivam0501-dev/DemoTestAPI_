using DemoTestAPI.DataAccess.Entity;
using DemoTestAPI.DataAccess.UnitOfWork;
using DemoTestAPI.Models.Common;
using DemoTestAPI.Models.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StateController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region AddState

        [HttpPost("AddState")]
        public async Task<Status> AddState(AddStateVM stateVM)
        {
            Status s = new Status();
            StateVM state = new() {
                StateCode= stateVM.StateCode,
                StateName= stateVM.StateName,
                CountryID=stateVM.CountryID,
            };
            var AddState = await _unitOfWork.stateRepository.AddState(state);
            s.statusCode = AddState.statusCode;
            s.message = AddState.message;
            return s;
        }

        #endregion AddEmployee

        #region DeleteState

        [HttpDelete("DeleteState")]
        public async Task<Status> DeleteState(int? Id)
        {
            Status s = new Status();
            var StateExists = await _unitOfWork.stateRepository.GetStatebyid(Id);
            if (StateExists != null)
            {
                var DeleteState = await _unitOfWork.stateRepository.DeleteState(StateExists);
                s.message = DeleteState.message;
                s.statusCode = DeleteState.statusCode;
            }
            return s;
        }

        #endregion 

        #region UpdateState

        [HttpPut("UpdateState")]
        public async Task<Status> UpdateState(StateVM state)
        {
            Status s = new Status();
            var stateExists = await _unitOfWork.stateRepository.GetStatebyid(state.StateId);
            if (stateExists != null)
            {
                stateExists.StateCode = state.StateCode;
                stateExists.StateName = state.StateName;
                stateExists.CountryID = state.CountryID;

                var UpdateState = await _unitOfWork.stateRepository.UpdateState(stateExists);
                s.message = UpdateState.message;
                s.statusCode = UpdateState.statusCode;
            }
            return s;

        }

        #endregion UpdateEmployee

        #region GetAllState
        [HttpGet("GetAllState")]
        public async Task<List<State>> GetAllState()
        {
            var GetAllState = await _unitOfWork.stateRepository.GetAllState();
                return GetAllState;
        }

        #endregion GetAlCountry

        #region GetStateById

        [HttpGet("GetStateById")]
        public async Task<State> GetStateById(int Id)
        {
            var GetStateById = await _unitOfWork.stateRepository.GetStatebyid(Id);
            return GetStateById;
        }

        #endregion
    }
}
