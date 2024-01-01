using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Domain.Models;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest<UpdateAuthorCommandResponse>, IMapTo<AuthorModel>
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateAuthorCommand, AuthorModel>(MemberList.Destination);
        }
    }

    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<UpdateAuthorCommandResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Author>();

            var author = repository.FindBy(a => a.Id == request.Id).FirstOrDefault();

            author.UpdateAuthor(_mapper.Map<AuthorModel>(request));

            repository.Update(author);

            _unitOfWork.CommitAsync();

            return Task.FromResult(_mapper.Map<UpdateAuthorCommandResponse>(author));
            
        }
    }
}
