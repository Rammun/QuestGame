using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DTO.ResponseDTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Status { get; set; }
        public string Body { get; set; }
        public string ErrorMessage { get; set; }
    }
}
