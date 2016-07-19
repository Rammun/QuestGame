using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Areas.Game.Models
{
    public class QuestViewModel
    {
        public string Title { get; set; }
        public ICollection<string> Frames { get; set; }

        public QuestViewModel()
        {
            Frames = new List<string>();
        }
    }

    public class QuestTitleViewModel
    {
        public string Title { get; set; }
        public string Owner { get; set; }
        public DateTime Date { get; set; }
    }
}