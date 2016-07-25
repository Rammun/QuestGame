using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DTO
{
    public class FrameDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }        
        public ICollection<TransitionDTO> Transitions { get; set; }
    }
}
