using System;
using System.Net.Http;

namespace Fundamentals.HttpClients
{
    public interface ICurrencyClient
    {
        public HttpClient Client { get; }
    }

    public class CurrencyClientImpl : ICurrencyClient
    {
        public HttpClient Client { get; private set; }

        public CurrencyClientImpl(HttpClient client)
        {
            Client = client;
            Client.BaseAddress = new Uri("https://cdn.jsdelivr.net/gh/fawazahmed0/currency-api@1/latest/");
        }
    }
}
