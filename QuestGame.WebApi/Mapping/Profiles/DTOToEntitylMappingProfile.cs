﻿using AutoMapper;
using QuestGame.Domain.DTO;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.Domain.Entities;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Mapping.Profiles
{
    public class DTOToEntitylMappingProfile : Profile
    {
        public DTOToEntitylMappingProfile()
        {
            CreateMap<QuestDTO, Quest>().ForMember(x => x.Owner, y => y.Ignore());
        }

        public override string ProfileName
        {
            get { return "DTOToEntitylMappingProfile"; }
        }
    }
}