using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Models
{
    public class QuestViewModel
    {
        public string Title { get; set; }
        public string Owner { get; set; }
        public DateTime Date { get; set; }
    }
}