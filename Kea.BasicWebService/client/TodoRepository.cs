using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    }
}