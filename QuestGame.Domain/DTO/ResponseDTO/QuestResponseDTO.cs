﻿using QuestGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DTO.ResponseDTO
{
    public class QuestResponseDTO
    {
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Owner { get; set; }        
    }
}
