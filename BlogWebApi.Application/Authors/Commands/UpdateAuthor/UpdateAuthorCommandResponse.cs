using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;
using System.Collections.Generic;

namespace BlogWebApi.Application.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandResponse : IMapFrom<Author>
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public IEnumerable<Post> Posts { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, UpdateAuthorCommandResponse>()
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
