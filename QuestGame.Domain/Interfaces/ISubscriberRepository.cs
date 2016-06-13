﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;

namespace QuestGame.Domain.Interfaces
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        IEnumerable<Subscriber> GetByOwnerId(long vkId);
    }
}
