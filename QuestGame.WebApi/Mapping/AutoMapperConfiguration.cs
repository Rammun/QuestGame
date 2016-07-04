using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace QuestGame.WebApi.Mapping
{
    public class AutoMapperConfiguration
    {

        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                //x.AddProfile<DtoToModelNSMappingProfile>();
                //x.AddProfile<ModelToDtoNSMappingProfile>();
            });
        } 
    }
}