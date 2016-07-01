﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Entities
{
    public class Quest
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public virtual ApplicationUser OwnerId { get; set; }
    }
}
