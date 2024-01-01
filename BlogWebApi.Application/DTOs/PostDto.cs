using System;
using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.DTOs
{
    public class PostDto : IMapFrom<Post>
    {
        public long PostId { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostDto>()
                .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.Id));
        }
    }
}