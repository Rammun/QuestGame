using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using QuestGame.Domain.Entities;
using QuestGame.Domain.DTO.ResponseDTO;

namespace QuestGame.WebApi.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper GetMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quest, QuestResponseDTO>().ForMember("Owner", x => x.MapFrom(pr => pr.Owner.UserName));
                                                        //.ForMember("Id", x => x.Ignore())
                                                        //.ForMember("OwnerId", x => x.Ignore());
                
            }).CreateMapper();
        } 
    }
}