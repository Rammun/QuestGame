using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.WebApi.Helpers
{
    public interface IRequestHelper
    {
        Task<string> PostAsJson(string method, object param);
        Task<string> Post(string method, string param);
    }
}
