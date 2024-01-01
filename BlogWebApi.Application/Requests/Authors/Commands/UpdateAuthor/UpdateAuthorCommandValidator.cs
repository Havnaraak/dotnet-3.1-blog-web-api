using BlogWebApi.Application.Common.Validators;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using FluentValidation;

namespace BlogWebApi.Application.Requests.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : ValidatorBase<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleFor(a => a.Id)
                .Must(IsValidId)
                .WithMessage("É necessário informar um ID válido");

            RuleFor(a => a.Name)
                .NotNull()
                .Length(2, 100);

            RuleFor(a => a.Photo)
                .NotNull()
                .Length(2, 100);
        }

        private bool IsValidId(long id) => UnitOfWork.GetRepository<Author>().Exists(a => a.Id == id);
    }
}
