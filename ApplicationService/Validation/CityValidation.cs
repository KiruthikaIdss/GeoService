using DataService;
using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationService.Validation
{
    public class CityValidation : AbstractValidator<City>
	{
		private readonly CountryDbContext _Dbcontext;

		public CityValidation(CountryDbContext Dbcontext)

		{
			_Dbcontext = Dbcontext;
		}
		public CityValidation()
		{
			RuleFor(x => x.CityId).NotNull();
			RuleFor(x => x.CityName).Length(0, 50);

			RuleFor(m => m).Must(model =>
					   !IsCodeUnique(model.Citycode, model.CityId))
					  .WithMessage("Code must be unique");
		}
		public bool IsCodeUnique(string Code, int id)
		{
			return _Dbcontext.Set<City>().Any(x => x.Citycode == Code && x.CityId != id);
		}
    
    
    }
}
