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
        public IEnumerable<Quest> Quests { get; set; }
    }
}
