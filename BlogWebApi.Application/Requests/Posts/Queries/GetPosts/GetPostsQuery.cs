using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Application.Requests.Posts.Queries.GetPosts
{
    public class GetPostsQuery : IRequest<IEnumerable<GetPostsQueryResponse>>
    {
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, IEnumerable<GetPostsQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<GetPostsQueryResponse>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Post>();

            return await repository.GetAll()
                .ProjectTo<GetPostsQueryResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}