using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.BusinessLogic.Models
{
    public class Quest
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<Frame> Frames { get; set; }

        public Quest()
        {
            Frames = new List<Frame>();
        }
    }
}
