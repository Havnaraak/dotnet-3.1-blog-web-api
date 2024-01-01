using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;

namespace BlogWebApi.Application.Requests.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest
    {
        public long PostId { get; set; }
    }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePostCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Post>();

            var post = repository.FindBy(p => p.Id == request.PostId).FirstOrDefault();
            
            repository.Delete(post);

            await _unitOfWork.CommitAsync(cancellationToken);
        }
    }
}