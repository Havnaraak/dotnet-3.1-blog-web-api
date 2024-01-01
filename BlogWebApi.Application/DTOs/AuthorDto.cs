using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.DTOs
{
    public class AuthorDto : IMapFrom<Author>
    {
        public long AuthorId { get; set; }
        
        public string Name { get; set; }

        public string Photo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, AuthorDto>()
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}