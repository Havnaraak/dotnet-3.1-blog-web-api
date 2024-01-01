using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.Requests.Posts.Commands.CreatePost
{
    public class CreatePostCommandResponse : IMapFrom<Post>
    {
        public long PostId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, CreatePostCommandResponse>(MemberList.Destination)
                .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.Id));
        }
    }
}