using System.Collections.Generic;
using AutoMapper;
using BlogWebApi.Application.DTOs;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.Requests.Authors.Queries.GetAuthors
{
    public class GetAuthorsQueryResponse : IMapFrom<Author>
    {
        public long AuthorId { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public IEnumerable<PostDto> Posts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, GetAuthorsQueryResponse>()
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
