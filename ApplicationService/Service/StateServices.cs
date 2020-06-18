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
    public class StateServices:IStateServices
    {
        private readonly IMapper _mapper;
        private readonly CountryDbContext _dbContext;
        public StateServices(CountryDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<StateModel> GetAll(int id)
        {
            var states = _dbContext.State.AsNoTracking();
            return _mapper.Map<IEnumerable<StateModel>>(states);
        }

        public async Task<StateModel> GetById(int id)
        {
            var state = await _dbContext.State
                        .AsNoTracking()
                        .FirstOrDefaultAsync(e => e.StateId == id);

            return _mapper.Map<StateModel>(state);
        }

        public void Create(StateModel stateModel)
        {
            var state = _mapper.Map<State>(stateModel);

            // await _dbContext.Country.AddAsync(country);
            // await _dbContext.SaveChangesAsync();
            _dbContext.Add(state).State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public async Task Update(int id, StateModel stateModel)
        {
            var state = _mapper.Map<State>(stateModel);

            _dbContext.State.Update(state);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var state = await _dbContext.State.FindAsync(id);
            _dbContext.State.Remove(state);
            await _dbContext.SaveChangesAsync();
        }
    }
}
    

