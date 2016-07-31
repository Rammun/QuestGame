﻿using AutoMapper;
using QuestGame.Common.Interfaces;
using QuestGame.Domain;
using QuestGame.Domain.DTO;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestGame.WebApi.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        IDataManager dataManager;
        //IMapper mapper;
        //ILoggerService logger;

        public ValuesController(IDataManager dataManager)
        //                        IMapper mapper,
        //                        ILoggerService logger)
        {
            this.dataManager = dataManager;
        }
        //    this.mapper = mapper;
        //    this.logger = logger;
        //}
        public ValuesController()
        {
        }
        
        // GET api/values
        [Authorize]
        [HttpGet]
        [Route("Authorize")]
        public string Get()
        {
            return "Authorize";
        }

        // GET api/values/5
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Admin")]
        public string Admin()
        {
            return "Admin";
        }

        // POST api/values
        public void Post(QuestDTO quest)
        {
            //var dbContext = new ApplicationDbContext();
            //var dataManager = new DataManager(dbContext,
            //               new EFQuestRepository(dbContext),
            //               new EFStageRepository(dbContext),
            //               new EFMotionRepository(dbContext));

            var owner = dataManager.Users.FirstOrDefault(u => u.UserName == quest.Owner);
            if (owner == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var qqq = new Quest
            {
                Date = DateTime.Now,
                Title = quest.Title,
                Owner = owner
            };

            try
            {
                dataManager.Quests.Add(qqq);
                dataManager.Save();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // PUT api/values/5
        public void Put()
        {
            
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
