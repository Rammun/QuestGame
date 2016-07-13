using AutoMapper;
using QuestGame.Common.Interfaces;
using QuestGame.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestGame.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {
        IDataManager dataManager;
        IMapper mapper;
        ILoggerService logger;

        public BaseApiController(IDataManager dataManager,
                                 IMapper mapper,
                                 ILoggerService logger)
        {
            this.dataManager = dataManager;
            this.mapper = mapper;
            this.logger = logger;
        }
    }
}
