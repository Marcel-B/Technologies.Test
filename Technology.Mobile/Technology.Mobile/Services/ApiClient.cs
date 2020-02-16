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
            _client.BaseAddress = new Uri("https://data.slipways.de/graphql");
        }

        public async Task<string> GetData()
        {
            var stringContent = new StringContent("{\"query\":\"query { slipways { id city name longitude latitude costs water { id longname shortname } extras { id name }}}\"}", Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("", stringContent);

            if (response.IsSuccessStatusCode)
            {
                var resp = await response.Content.ReadAsStringAsync();
                return resp;
            }
            return string.Empty;
        }
    }
}
