using ApplicationService.ViewModel;
using AutoMapper;
using DataService;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationService.Service
{

    public class CountryService : ICountryServices
    {
        private readonly IMapper _mapper;
        private readonly CountryDbContext _dbContext;

        public CountryService(CountryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<CountryModel> GetAll(int id)
        {
            var countries = _dbContext.Country.AsNoTracking();
            return _mapper.Map<IEnumerable<CountryModel>>(countries);
        }

        public async Task<CountryModel> GetById(int id)
        {
            var country = await _dbContext.Country
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.CountryId == id);

            return _mapper.Map<CountryModel>(country);
        }

        public void Create(CountryModel countryModel)
        {
            var country = _mapper.Map<Country>(countryModel);

            // await _dbContext.Country.AddAsync(country);
            // await _dbContext.SaveChangesAsync();
           _dbContext.Add(country).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public async Task Update(int id, CountryModel countryModel)
        {
            var country = _mapper.Map<Country>(countryModel);

            _dbContext.Country.Update(country);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var country = await _dbContext.Country.FindAsync(id);
            _dbContext.Country.Remove(country);
            await _dbContext.SaveChangesAsync();
        }
    }
}



