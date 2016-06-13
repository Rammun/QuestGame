using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;

namespace QuestGame.Domain.Interfaces
{
    public interface IFriendRepository : IRepository<Friend>
    {
        IEnumerable<Friend> GetByOwnerId(long vkId);
    }
}
