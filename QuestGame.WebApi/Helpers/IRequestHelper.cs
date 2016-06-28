using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.WebApi.Helpers
{
    public interface IRequestHelper
    {
        Task<object> PostAsync<T>(string method, Dictionary<string, string> param);
		string Post(string method, Dictionary<string, string> param);
        HttpResponseMessage PostAsJson(string method, object param);
    }
}
