using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Technology.Mobile.Services
{
    public class ApiClient
    {
        private HttpClient _client;

        public ApiClient(
            HttpClient client = null)
        {
            _client = client ?? new HttpClient();
        }

        public async Task<string> GetData()
        {
            //curl ' - H 'Accept-Encoding: gzip, deflate, br' - H 'Content-Type: application/json' - H 'Accept: application/json' - H 'Connection: keep-alive' - H 'DNT: 1' - H 'Origin: https://data.slipways.de'--data - binary ''--compressed
            _client.BaseAddress = new Uri("https://data.slipways.de/graphql");
            var stringContent = new StringContent("{\"query\":\"query {\n  slipways {\n    id\n    city\n    name\n    longitude\n    latitude\n    costs\n    water {\n      id\n      longname\n      shortname\n    }\n    extras {  id  name }}}\"}", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                Console.WriteLine(resp);
                return resp;
            }
            return string.Empty;
        }
    }
}
