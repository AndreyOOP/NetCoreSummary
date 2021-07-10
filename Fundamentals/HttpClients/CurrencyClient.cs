using System;
using System.Net.Http;

namespace Fundamentals.HttpClients
{
    public class CurrencyClient
    {
        public HttpClient Client { get; private set; }

        public CurrencyClient(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/");
        }
    }
}
