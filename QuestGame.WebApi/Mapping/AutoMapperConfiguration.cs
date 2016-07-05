﻿using AutoMapper;
using QuestGame.WebApi.Mapping.Profiles;

namespace QuestGame.WebApi.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper CreatetMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ModelToDTOMappingProfile>();
                cfg.AddProfile<DTOToModelMappingProfile>();
            }).CreateMapper();
        } 
    }
}