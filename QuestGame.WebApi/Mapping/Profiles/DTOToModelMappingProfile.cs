using AutoMapper;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Mapping.Profiles
{
    public class DTOToModelMappingProfile : Profile
    {
        public DTOToModelMappingProfile()
        {
            //CreateMap<QuestResponseDTO, QuestViewModel>();
        }

        public override string ProfileName
        {
            get { return "DTOToModelMappingProfile"; }
        }
    }
}