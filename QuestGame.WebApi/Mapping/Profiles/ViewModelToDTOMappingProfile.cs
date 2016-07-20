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
            CreateMap<NewQuestViewModel, QuestDTO>().ForMember(b => b.Frames, c => c.UseValue(new List<Frame>()))
                                                    .ForMember(d => d.Date, k => k.UseValue(DateTime.Now));
        }

        public override string ProfileName
        {
            get { return "ViewModelToDTOMappingProfile"; }
        }
    }
}