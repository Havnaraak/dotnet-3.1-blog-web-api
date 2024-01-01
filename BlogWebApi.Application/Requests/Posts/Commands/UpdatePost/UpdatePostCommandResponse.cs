using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.Requests.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandResponse : IMapFrom<Post>
    {
        public long PostId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, UpdatePostCommandResponse>(MemberList.Destination)
                .ForMember(d => d.PostId, opt => opt.MapFrom(src => src.Id));
        }
    }
}