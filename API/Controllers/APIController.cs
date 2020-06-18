using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService.Service;
using ApplicationService.ViewModel;
using AutoMapper;
using Entity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class APIController : ControllerBase
    {
        private readonly ICountryServices _service;
        public APIController(ICountryServices service)
        {
            _service = service;
        }
        [HttpDelete("Delete")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);

        }
        [HttpPost("Create")]
        public void Create(CountryModel countryModel)
        {

             _service.Create(countryModel);

        }
        [HttpPut("Update")]
        public async Task Update(int id, CountryModel countryModel)
        {
            await _service.Update(id,countryModel);

        }
        [HttpGet("GetById")]
        public async Task<CountryModel> GetById(int id)
        {
           CountryModel x =  await _service.GetById(id);
            return x;
        }
        [HttpGet("GetAll")]
        public IEnumerable<CountryModel> GetAll(int id)
        {
            return _service.GetAll(id);
        }

    }
}