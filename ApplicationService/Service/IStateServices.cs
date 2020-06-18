using ApplicationService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Service
{

    public interface IStateServices
    {
        IEnumerable<StateModel> GetAll(int id);

        Task<StateModel> GetById(int id);

        void Create(StateModel stateModel);

        Task Update(int id, StateModel stateModel);

        Task Delete(int id);
    }
}
