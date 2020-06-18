using ApplicationService.ViewModel;
using AutoMapper;
using DataService;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Service
{
    public class CityServices : ICityServices
    {
        private readonly IMapper _mapper;
        private readonly CountryDbContext _dbContext;
        public CityServices(CountryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CityModel> GetAll(int id)
        {
            var cities = _dbContext.City.AsNoTracking();
            return _mapper.Map<IEnumerable<CityModel>>(cities);
        }

        public async Task<CityModel> GetById(int id)
        {
            var city = await _dbContext.City
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.CityId == id);

            return _mapper.Map<CityModel>(city);
        }

        public void Create(CityModel cityModel)
        {
            var city = _mapper.Map<City>(cityModel);

            // await _dbContext.Country.AddAsync(country);
            // await _dbContext.SaveChangesAsync();
            _dbContext.Add(city).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public async Task Update(int id, CityModel cityModel)
        {
            var city = _mapper.Map<City>(cityModel);

            _dbContext.City.Update(city);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var city = await _dbContext.City.FindAsync(id);
            _dbContext.City.Remove(city);
            await _dbContext.SaveChangesAsync();
        }
    }
}
