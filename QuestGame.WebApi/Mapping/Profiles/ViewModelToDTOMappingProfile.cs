using AutoMapper;
using QuestGame.Domain.DTO;
using QuestGame.Domain.Entities;
using QuestGame.WebApi.Areas.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Mapping.Profiles
{
    public class ViewModelToDTOMappingProfile : Profile
    {
        public ViewModelToDTOMappingProfile()
        {
            CreateMap<QuestViewModel, QuestDTO>();
            CreateMap<NewQuestViewModel, QuestDTO>();//.ForMember(b => b.Stages, c => c.UseValue(new List<StageDTO>()))
                                                     //.ForMember(d => d.Date, k => k.UseValue(DateTime.Now));
            CreateMap<StageViewModel, StageDTO>();
            CreateMap<MotionViewModel, MotionDTO>();
        }

        public override string ProfileName
        {
            get { return "ViewModelToDTOMappingProfile"; }
        }
    }
}