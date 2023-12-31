﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlogWebApi.Domain.Entities;
using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogWebApi.Application.Requests.Authors.Queries.GetAuthors
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

        public async Task<List<GetAuthorsQueryResponse>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.GetRepository<Author>();

            return await repository.GetAll()
                    .ProjectTo<GetAuthorsQueryResponse>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
        }
    }
}
