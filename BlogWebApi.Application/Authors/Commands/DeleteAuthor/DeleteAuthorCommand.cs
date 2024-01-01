using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Authors.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public long Id { get; set; }
    }

    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Author>();

            var author = repository.FindBy(a => a.Id == request.Id).FirstOrDefault();

            repository.Delete(author);

            _unitOfWork.CommitAsync();

            return Task.CompletedTask;
        }
    }
}
