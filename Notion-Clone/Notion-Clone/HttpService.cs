using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Notion_Clone
{
    public class HttpService
    {
        private HttpClient _httpClient;
        private const string Media_Type = "application/json";
        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public string GenerateUrl()
        {
            string apiURL = ConfigurationManager.AppSettings["AddTaskApi"];
            _httpClient.BaseAddress = new Uri(apiURL);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Media_Type));
            return apiURL;
        }
        public StringContent PutContent(string data) 
        {
            return new StringContent(data, Encoding.UTF8, Media_Type);
        }
        public HttpResponseMessage ExaminePostVerb(string apiURL, StringContent content) 
        {
            return _httpClient.PostAsync(apiURL, content).Result;
        }
    }
}
