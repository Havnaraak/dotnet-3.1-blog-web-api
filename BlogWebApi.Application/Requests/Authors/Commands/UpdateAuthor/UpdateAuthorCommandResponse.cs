using AutoMapper;
using BlogWebApi.Application.Interfaces;
using BlogWebApi.Domain.Entities;

namespace BlogWebApi.Application.Requests.Authors.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandResponse : IMapFrom<Author>
    {
        public int AuthorId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Author, UpdateAuthorCommandResponse>(MemberList.Destination)
                .ForMember(d => d.AuthorId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
