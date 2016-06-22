using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.WebApi.Helpers
{
    public interface IRequestHelper
    {
        Task<string> PostAsJsonAsync(string method, object param);
        Task<string> PostAsync(string method, Dictionary<string, string> param);
    }
}
