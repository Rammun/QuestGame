using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Mapping.Profiles
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {

        }

        public override string ProfileName
        {
            get
            {
                return "EntityToDTOMappingProfile";
            }
        }
    }
}