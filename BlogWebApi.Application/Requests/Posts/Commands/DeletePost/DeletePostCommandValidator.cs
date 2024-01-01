using BlogWebApi.Application.Common.Validators;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using FluentValidation;

namespace BlogWebApi.Application.Requests.Posts.Commands.DeletePost
{
    public class DeletePostCommandValidator : ValidatorBase<DeletePostCommand>
    {
        public DeletePostCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleFor(p => p.PostId)
                .Must(IsValidId);
        }

        private bool IsValidId(long id) => UnitOfWork.GetRepository<Post>().Exists(p => p.Id == id);
    }
}