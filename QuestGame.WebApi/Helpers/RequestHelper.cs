using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace QuestGame.WebApi.Helpers
{
    public class RequestHelper : IRequestHelper
    {
        public static string BaseUrl = WebConfigurationManager.AppSettings["BaseUrl"];

        public static void Setting(HttpClient client)
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void Setting(HttpClient client, string authToken)
        {
            RequestHelper.Setting(client);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authToken);
        }

        public HttpResponseMessage PostAsJson(string method, object param)
        {
            using (var client = new HttpClient())
            {
                RequestHelper.Setting(client);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
                {
                    var response = client.PostAsJsonAsync(method, param).Result;
                    //var answer = await response.Content.ReadAsAsync<T>();
                    return response;
                }
                catch(Exception ex)
                {
                    throw new Exception("Ошибка запроса: " + ex.Message);
                }
            }
        }

		public async Task<object> PostAsync<T>(string method, Dictionary<string, string> param)
		{
			using (var client = new HttpClient())
			{
				RequestHelper.Setting(client);

				try
				{
					var content = new FormUrlEncodedContent(param);
					var response = await client.PostAsync(method, content);
					var answer = await response.Content.ReadAsAsync<T>();
					return answer;
				}
				catch (Exception ex)
				{
					Debug.WriteLine("Ошибка запроса" + ex.Message);
					return ex.Message;
				}
			}
		}

		public string Post(string method, Dictionary<string, string> param)
        {
            using (var client = new HttpClient())
            {
                RequestHelper.Setting(client);

				try
				{
					var content = new FormUrlEncodedContent(param);
					var response = client.PostAsync(method, content).Result;
					var answer = response.Content.ReadAsAsync<string>().Result;
					return answer;
				}
				catch (Exception ex)
				{
					Debug.WriteLine("--- Ошибка запроса:  -" + ex.Message);
					return ex.Message;
				}
			}
        }
    }	
}