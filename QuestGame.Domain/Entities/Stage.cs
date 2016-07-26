﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Entities
{
    public class Stage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public int QuestId { get; set; }
        public virtual Quest Quest { get; set; }

        public virtual ICollection<Motion> Motions { get; set; }

        public Stage()
        {
            Motions = new List<Motion>();
        }
    }
}
