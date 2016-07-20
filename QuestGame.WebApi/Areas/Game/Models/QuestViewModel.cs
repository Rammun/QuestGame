using QuestGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestGame.WebApi.Areas.Game.Models
{
    public class QuestViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }   
    }

    public class NewQuestViewModel
    {
        public string Title { get; set; }
        public string Owner { get; set; }
    }
}