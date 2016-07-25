using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DTO
{
    public class TransitionDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int FrameId { get; set; }
    }
}
