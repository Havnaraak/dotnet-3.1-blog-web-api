using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.Requests.Authors.Commands.CreateAuthor
{
    public class CreateAuthorCommandResponse : IMapFrom<Author>
    {
        public long AuthorId { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, CreateAuthorCommandResponse>(MemberList.Destination)
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
