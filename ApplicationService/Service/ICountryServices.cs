using ApplicationService.ViewModel;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Service
{
    public interface ICountryServices
    {
         IEnumerable<CountryModel> GetAll(int id);

        Task<CountryModel> GetById(int id);

        void Create(CountryModel countryModel);

        Task Update(int id, CountryModel countryModel);

        Task Delete(int id);
    }
}

