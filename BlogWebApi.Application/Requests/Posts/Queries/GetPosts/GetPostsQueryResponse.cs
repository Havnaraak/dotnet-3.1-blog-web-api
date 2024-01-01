using System;
using AutoMapper;
using BlogWebApi.Application.DTOs;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.Requests.Posts.Queries.GetPosts
{
    public class GetPostsQueryResponse : IMapFrom<Post>
    {
        public long PostId { get; set; }
        
        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }

        public AuthorDto Author { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, GetPostsQueryResponse>()
                .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.Id));
        }
    }
}