using AutoMapper;

namespace BlogWebApi.Application.Interfaces
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

    }
}
