using MyDemoAPI.Entities;
using Newtonsoft.Json;

namespace MyDemoAPI.Services
{
    public class ConsumirAPIPersonaService : IConsumirAPIPersonaService
    {
        private  HttpClient _httpClient;
        public async Task<List<Persona>> GetPersonas()
        {
            List<Persona> result=null;
            _httpClient=new HttpClient();
            string url = @"https://localhost:5001/Persona";
            string token="";

            using(HttpRequestMessage request = 
            new HttpRequestMessage(HttpMethod.Get, url))
            {
                request.Headers.Authorization=
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                using(HttpResponseMessage response =await _httpClient.SendAsync(request))
                {
                    using(HttpContent content = response.Content)
                    {
                        if(response.IsSuccessStatusCode)
                        {
                        string data = await content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<Persona>>(data);
                        }

                    }
                }
            }

            return result;
        }   
    }
}