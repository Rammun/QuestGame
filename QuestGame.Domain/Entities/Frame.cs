using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Entities
{
    public class Frame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public int QuestId { get; set; }
        public virtual Quest Quest { get; set; }

        public virtual ICollection<Transition> Transitions { get; set; }

        public Frame()
        {
            Transitions = new List<Transition>();
        }
    }
}
