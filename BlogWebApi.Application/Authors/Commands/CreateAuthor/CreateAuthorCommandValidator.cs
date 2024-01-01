using BlogWebApi.Application.Common.Validators;
using FluentValidation;

namespace BlogWebApi.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : ValidatorBase<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .Length(2, 100);

            RuleFor(a => a.Photo)
                .NotNull()
                .Length(2, 100);
        }
    }
}
