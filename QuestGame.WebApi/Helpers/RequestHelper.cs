using Newtonsoft.Json;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace QuestGame.WebApi.Helpers
{
    public class RequestHelper : IRequestHelper
    {
        private string baseUrl;

        public RequestHelper()
        {
            baseUrl = WebConfigurationManager.AppSettings["BaseUrl"];
        }

        public async Task<string> PostAsJson(string method, object param)
        {
            using (var client = new HttpClient())
            {
                SettingHttpClient(baseUrl, client);

                var response = await client.PostAsJsonAsync(method, param);
                var answer = await response.Content.ReadAsAsync<string>();
                return answer;
            }
        }

        //public async Task<string> Post(string method, string param)
        //{
        //    using (var client = new HttpClient())
        //    {
        //        SettingHttpClient(baseUrl, client);

        //        var container = new List<KeyValuePair<string,string>>
        //        {
        //            new KeyValuePair<string, string>{ "me"}
        //        }
        //        var content = new FormUrlEncodedContent(new List<KeyValuePair<string,string>>());
        //        var response = await client.PostAsync(method, content);
        //        var answer = await response.Content.ReadAsAsync<string>();
        //        return answer;
        //    }
        //}

        public Task<string> Post(string method, string param)
        {
            throw new NotImplementedException();
        }

        private void SettingHttpClient(string baseUrl, HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



    }
}