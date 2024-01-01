using BlogWebApi.Application.Common.Validators;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using FluentValidation;

namespace BlogWebApi.Application.Requests.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandValidator : ValidatorBase<UpdatePostCommand>
    {
        public UpdatePostCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleFor(p => p.AuthorId)
                .Must(IsValidAuthorId);

            RuleFor(p => p.Id)
                .Must(IsValidId);
            
            RuleFor(p => p.Content)
                .NotNull()
                .Length(2, 300);

            RuleFor(p => p.Title)
                .NotNull()
                .Length(2, 80);
        }

        private bool IsValidAuthorId(long id) => UnitOfWork.GetRepository<Author>().Exists(a => a.Id == id);
        
        private bool IsValidId(long id) =>  UnitOfWork.GetRepository<Post>().Exists(p => p.Id == id);
    }
}