﻿using AutoMapper;

namespace BlogWebApi.Application.Interfaces
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
