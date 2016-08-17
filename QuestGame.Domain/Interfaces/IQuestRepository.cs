using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;

namespace QuestGame.Domain.Interfaces
{
    public interface IQuestRepository : ICommonRepository<Quest>
    {
        IEnumerable<Quest> GetQuestsByOwnerName(string name);
        Quest GetByTitle(string title);
        void DelByTitle(string title);
    }
}
