using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Entities
{
    public class Motion
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int NextFrameId { get; set; }
        public virtual Stage NextFrame { get; set; }

        public int OwnerFrameId { get; set; }
        public virtual Stage OwnerFrame { get; set; }
    }
}
