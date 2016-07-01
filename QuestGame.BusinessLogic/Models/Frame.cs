using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestGame.BusinessLogic.Models
{
    public class Frame
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public ICollection<Transition> Transitions { get; set; }

        public Frame()
        {
            Transitions = new List<Transition>();
        }
    }
}
