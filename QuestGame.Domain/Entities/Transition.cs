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

        public int NextFrameId { get; set; }
        public virtual Frame NextFrame { get; set; }

        public int OwnerFrameId { get; set; }
        public virtual Frame OwnerFrame { get; set; }
    }
}
