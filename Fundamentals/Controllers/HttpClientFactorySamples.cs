using Fundamentals.HttpClients;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fundamentals.Controllers
{
    [Route("clients")]
    [ApiController]
    public class HttpClientFactorySamples : ControllerBase
    {
        private HttpClient dogsClient;
        private HttpClient currencyClient;

        public HttpClientFactorySamples(IHttpClientFactory factory, CurrencyClient currencyClient)
        {
            dogsClient = factory.CreateClient("Dogs");
            this.currencyClient = currencyClient.Client;
        }

        // the sample of NAMED http client usage
        [HttpGet("dog-client")]
        public async Task<DogImg> GetDogImageUrl()
        {
            var resposne = await dogsClient.GetAsync("image/random"); // Important: do not place / at the begining
            var json = await resposne.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<DogImg>(json);
        }

        // the sample of TYPED http client usage
        [HttpGet("currency-list")]
        public async Task<IActionResult> GetCurrencies()
        {
            var resposne = await currencyClient.GetAsync("currencies.json");
            resposne.EnsureSuccessStatusCode();
            return new ContentResult
            {
                Content = await resposne.Content.ReadAsStringAsync()
            };
        }

    }

    public class DogImg
    {
        public string message { get; set; }
        public string status { get; set; }
    }
}
