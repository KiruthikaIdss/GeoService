using ApplicationService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Service
{
    public interface ICityServices
    {
        IEnumerable<CityModel> GetAll(int id);

        Task<CityModel> GetById(int id);

        void Create(CityModel cityModel);

        Task Update(int id, CityModel cityModel);

        Task Delete(int id);
    }
}
