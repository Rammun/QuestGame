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
        private string baseUrl;

        public RequestHelper()
        {
            baseUrl = WebConfigurationManager.AppSettings["BaseUrl"];
        }

        public async Task<object> PostAsJsonAsync<T>(string method, object param)
        {
            using (var client = new HttpClient())
            {
                SettingHttpClient(baseUrl, client);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
                {
                    var response = await client.PostAsJsonAsync(method, param);
                    var answer = await response.Content.ReadAsAsync<T>();
                    return answer;
                }
                catch(Exception ex)
                {
                    Debug.WriteLine("Ошибка запроса" + ex.Message);
                    return new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };
                }
            }
        }

		public async Task<object> PostAsync<T>(string method, Dictionary<string, string> param)
		{
			using (var client = new HttpClient())
			{
				SettingHttpClient(baseUrl, client);

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
				SettingHttpClient(baseUrl, client);

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

		private void SettingHttpClient(string baseUrl, HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Clear();            
        }
    }	
}