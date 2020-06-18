using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService.Service;
using ApplicationService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityServices _service;
        public CityController(ICityServices service)
        {
            _service = service;
        }
        [HttpDelete("Delete")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);

        }
        [HttpPost("Create")]
        public void Create(CityModel cityModel)
        {

            _service.Create(cityModel);

        }
        [HttpPut("Update")]
        public async Task Update(int id, CityModel cityModel)
        {
            await _service.Update(id, cityModel);

        }
        [HttpGet("GetById")]
        public async Task<CityModel> GetById(int id)
        {
            CityModel x = await _service.GetById(id);
            return x;
        }
        [HttpGet("GetAll")]
        public IEnumerable<CityModel> GetAll(int id)
        {
            return _service.GetAll( id);
        }
    }
}