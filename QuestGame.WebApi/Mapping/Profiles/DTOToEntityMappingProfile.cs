using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Mapping.Profiles
{
    public class DTOToEntityMappingProfile : Profile
    {
        public DTOToEntityMappingProfile()
        {

        }

        public override string ProfileName
        {
            get { return "DTOToEntityMappingProfile"; }
        }
    }
}