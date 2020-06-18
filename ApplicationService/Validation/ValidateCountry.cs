using DataService;
using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationService.Validation
{
	 public class ValidateCountry : AbstractValidator<Country>
	{
		private readonly CountryDbContext _Dbcontext;
	
	public ValidateCountry(CountryDbContext Dbcontext)

	{
		_Dbcontext = Dbcontext;
	}
		public ValidateCountry()
		{ 
			RuleFor(x => x.CountryId).NotNull();
			RuleFor(x => x.CountryName).Length(0, 50);

			RuleFor(m => m).Must(model =>
					   !IsCodeUnique(model.Countrycode, model.CountryId))
					  .WithMessage("Code must be unique");
		}
		public bool IsCodeUnique(string Code,int id)
		{
			return _Dbcontext.Set<Country>().Any(x => x.Countrycode == Code && x.CountryId != id);
		}
	}
}
