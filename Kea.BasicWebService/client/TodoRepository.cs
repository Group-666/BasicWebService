using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kea.BasicWebService.Client
{
    public class TodoRepository
    {
        private readonly HttpClient _client;
        private readonly string _url;

        public TodoRepository()
        {
            _client = new HttpClient();
            _url = "http://localhost:5000/api/todo";
        }

        public async Task<List<string>> GetAll()
        {
            var result = await _client.GetStringAsync(_url);

            return JsonConvert.DeserializeObject<List<string>>(result);
        }

        public async Task Remove(int index)
        {
            var response = await _client.DeleteAsync(_url + "/" + index);
            
            if (response.StatusCode != HttpStatusCode.OK)
                 throw new InvalidOperationException("The todo could not be removed in the todos.");
        }

        public async Task Add(string todo)
        {
            var json = new JObject
            {
                ["Description"] = todo
            };
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url, content);
            
            if (response.StatusCode != HttpStatusCode.OK)
                 throw new InvalidOperationException("The todo could not be saved in the todos.");
        }
    }
}