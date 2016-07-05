﻿using AutoMapper;
using QuestGame.Domain;
using QuestGame.Domain.DTO.RequestDTO;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestGame.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Quest")]
    public class QuestController : ApiController
    {
        IDataManager dataManager;
        IMapper mapper;

        public QuestController()
        {
            var dbContext = new ApplicationDbContext();
            this.dataManager = new DataManager(dbContext, new EFQuestRepository(dbContext));

            this.mapper = AutoMapperConfiguration.CreatetMappings();
        }

        // GET api/Quest
        public IEnumerable<QuestResponseDTO> Get()
        {
            var quests = dataManager.Quests.GetAll();

            var response = mapper.Map<IEnumerable<Quest>, IEnumerable<QuestResponseDTO>>(quests.ToList());
            return response;
        }

        // GET api/Quest/5
        public QuestResponseDTO Get(int id)
        {
            var quest = dataManager.Quests.GetById(id);
            if (quest == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var response = mapper.Map<Quest, QuestResponseDTO>(quest);
            return response;
        }

        // POST api/Quest
        public void Post(QuestRequestDTO quest)
        {
            var model = mapper.Map<QuestRequestDTO, Quest>(quest);
            var owner = dataManager.Users.FirstOrDefault(u => u.UserName == quest.Owner);
            if (owner == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            model.Owner = owner;

            dataManager.Quests.Add(model);
        }

        // DELETE api/Quest/5
        public void Delete(int id)
        {
            dataManager.Quests.Delete(id);
        }
    }
}
