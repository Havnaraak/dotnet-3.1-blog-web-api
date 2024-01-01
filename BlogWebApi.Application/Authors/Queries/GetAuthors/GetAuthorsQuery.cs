using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Application.Authors.Queries.GetAuthors
{
    public class GetAuthorsQuery : IRequest<List<GetAuthorsQueryResponse>>
    {
    }

    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<GetAuthorsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAuthorsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<GetAuthorsQueryResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Author>();

            return Task.FromResult(
                repository.GetAll()
                .ProjectTo<GetAuthorsQueryResponse>(_mapper.ConfigurationProvider)
                .ToList()
                );
        }
    }
}
