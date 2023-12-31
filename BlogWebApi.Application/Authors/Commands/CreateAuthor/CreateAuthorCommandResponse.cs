using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;
using System.Collections.Generic;

namespace BlogWebApi.Application.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandResponse : IMapFrom<Author>
    {
        public long AuthorId { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public IEnumerable<Post> Posts { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, CreateAuthorCommandResponse>()
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
