using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService.Service;
using ApplicationService.ViewModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateServices _service;
        public StateController(IStateServices service)
        {
            _service = service;
        }
        [HttpDelete("Delete")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);

        }
        [HttpPost("Create")]
        public void Create(StateModel stateModel)
        {

            _service.Create(stateModel);

        }
        [HttpPut("Update")]
        public async Task Update(int id, StateModel stateModel)
        {
            await _service.Update(id, stateModel);

        }
        [HttpGet("GetById")]
        public async Task<StateModel> GetById(int id)
        {
            StateModel x = await _service.GetById(id);
            return x;
        }
        [HttpGet("GetAll")]
        public IEnumerable<StateModel> GetAll(int id)
        {
            return _service.GetAll(id);
        }

    }
}
