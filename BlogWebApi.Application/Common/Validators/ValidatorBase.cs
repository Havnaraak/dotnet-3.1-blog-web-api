using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using FluentValidation;

namespace BlogWebApi.Application.Common.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T> 
    {
        protected ValidatorBase()
        {

        }

        protected ValidatorBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected IUnitOfWork UnitOfWork { get;  }
    }
}
