using FluentValidation;

namespace BlogWebApi.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotNull()
                .Length(2, 100);

            RuleFor(a => a.Photo)
                .NotNull();
        }
    }
}
