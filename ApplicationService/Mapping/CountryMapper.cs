using ApplicationService.Service;
using ApplicationService.ViewModel;
using AutoMapper;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService.Mapping
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
           CreateMap<Country, CountryReadModel>().ReverseMap();
           CreateMap<Country, CountryModel>().ReverseMap();
            CreateMap<State, StateReadModel>().ReverseMap();
            CreateMap<State, StateModel>().ReverseMap();
            CreateMap<City, CityReadModel>().ReverseMap();
            CreateMap<City, CityModel>().ReverseMap();
        }
    }
}
