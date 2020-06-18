using DataService;
using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationService.Validation
{
    class StateValidation : AbstractValidator<State>
	{
		private readonly CountryDbContext _Dbcontext;

		public StateValidation(CountryDbContext Dbcontext)

		{
			_Dbcontext = Dbcontext;
		}
		public StateValidation()
		{
			RuleFor(x => x.StateId).NotNull();
			RuleFor(x => x.StateName).Length(0, 50);

			RuleFor(m => m).Must(model =>
					   !IsCodeUnique(model.Statecode, model.StateId))
					  .WithMessage("Code must be unique");
		}
		public bool IsCodeUnique(string Code, int id)
		{
			return _Dbcontext.Set<State>().Any(x => x.Statecode == Code && x.StateId != id);
		}
    
    }
}
