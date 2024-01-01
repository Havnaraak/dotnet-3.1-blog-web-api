using BlogWebApi.Application.Common.Validators;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using FluentValidation;

namespace BlogWebApi.Application.Requests.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : ValidatorBase<CreatePostCommand>
    {
        public CreatePostCommandValidator(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            RuleFor(p => p.AuthorId)
                .Must(IsValidAuthorId)
                .WithMessage("É necessário informar um autor válido");
            
            RuleFor(p => p.Content)
                .NotNull()
                .Length(2, 300);

            RuleFor(p => p.Title)
                .NotNull()
                .Length(2, 80);
        }

        private bool IsValidAuthorId(long id) => UnitOfWork.GetRepository<Author>().Exists(a => a.Id == id);
    }
}