using Newtonsoft.Json;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<string> PostAsJsonAsync(string method, object param)
        {
            using (var client = new HttpClient())
            {
                SettingHttpClient(baseUrl, client);

                try
                {
                    var response = await client.PostAsJsonAsync(method, param);
                    var answer = await response.Content.ReadAsAsync<string>();
                    return answer;
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return ex.Message;
                }
                
                
            }
        }

        public async Task<string> PostAsync(string method, Dictionary<string, string> param)
        {
            using (var client = new HttpClient())
            {
                SettingHttpClient(baseUrl, client);

                var response = await client.PostAsync("/Token", new FormUrlEncodedContent(param));
                var answer = await response.Content.ReadAsAsync<string>();
                return answer;
            }
        }
        
        private void SettingHttpClient(string baseUrl, HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }



    }
}