using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Entities
{
    public class Transition
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int FrameId { get; set; }
        public virtual Frame Frame { get; set; }
    }
}
