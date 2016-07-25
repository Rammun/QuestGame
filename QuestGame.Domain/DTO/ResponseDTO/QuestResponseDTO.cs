using QuestGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DTO.ResponseDTO
{
    public class QuestResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public ApplicationUser Owner { get; set; }
        public ICollection<Stage> Frames { get; set; }      
    }
}
