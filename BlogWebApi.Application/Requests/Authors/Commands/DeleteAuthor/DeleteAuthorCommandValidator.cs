using System.Linq;
using BlogWebApi.Application.Common.Validators;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using FluentValidation;

namespace BlogWebApi.Application.Requests.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : ValidatorBase<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleFor(a => a.Id)
                .Must(IsValidId)
                .Must(CanDeleteAuthor)
                .WithMessage("Não é possível excluir o autor pois há posts atrelados. Exclua primeiro os posts antes de excluir o autor.");
        }

        private bool IsValidId(long id) => UnitOfWork.GetRepository<Author>().Exists(a => a.Id == id);

        private bool CanDeleteAuthor(long id) => !UnitOfWork.GetRepository<Post>().FindBy(p => p.Author.Id == id).Any();
    }
}
