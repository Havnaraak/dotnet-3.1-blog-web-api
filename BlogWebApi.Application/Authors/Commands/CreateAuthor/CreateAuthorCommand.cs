using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Models;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<CreateAuthorCommandResponse>, IMapTo<AuthorModel>
    {
        public string Name { get; set; }

        public string Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthorCommand, AuthorModel>(MemberList.Destination);
        }

    }

    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateAuthorCommandResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Author>();

            var authorDto = _mapper.Map<CreateAuthorCommand, AuthorModel>(request);

            var author = new Author(authorDto);

            repository.Add(author);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<CreateAuthorCommandResponse>(author);
        }
    }
}
