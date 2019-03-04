using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FDTS.Mobile.Services
{
    public class HttpService
    {
        private readonly string _accessToken;

        public HttpService(string url)
        {
            this.Url = url;
        }


        public string Url { get; set; }
       

        public async Task<JwtModel> Login()
        {
           
                HttpClient httpClient = new HttpClient();
                var res = await httpClient.GetStringAsync(Url);
                var users = JsonConvert.DeserializeObject<JwtModel>(res);

                return users;
           
            
        }
    }
}
