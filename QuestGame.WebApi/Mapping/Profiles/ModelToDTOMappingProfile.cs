using AutoMapper;
using QuestGame.Domain.DTO.RequestDTO;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Mapping.Profiles
{
    public class ModelToDTOMappingProfile : Profile
    {        
        public ModelToDTOMappingProfile()
        {
            CreateMap<Quest, QuestResponseDTO>().ForMember("Owner", x => x.MapFrom(pr => pr.Owner.UserName));
        }

        public override string ProfileName
        {
            get { return "ModelToDTOMappingProfile"; }
        }
    }
}