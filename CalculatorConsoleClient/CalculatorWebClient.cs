using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CalculatorConsoleClient
{
    class CalculatorWebClient
    {
        private static readonly HttpClient _HttpClient = new HttpClient();
        // ideally this would be in a config file somewhere
        private const string API_URL = "https://localhost:44342/";

        public CalculatorWebClient()
        {
            _HttpClient.BaseAddress = new Uri(API_URL);
            _HttpClient.DefaultRequestHeaders.Accept.Clear();
            _HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private static string GetApiEndpoint(string endpoint, int left, int right) =>
            $"calculator/{endpoint}?left={left}&right={right}";

        public int GetIntResult(HttpResponseMessage response)
        {
            var content = response.Content.ReadAsStringAsync().Result;
            return int.Parse(content);
        }

        public int Add(int left, int right)
        {
            var endpoint = GetApiEndpoint("add", left, right);
            var result = _HttpClient.GetAsync(endpoint).Result;
            return GetIntResult(result);
        }

        public int Subtract(int left, int right)
        {
            var endpoint = GetApiEndpoint("subtract", left, right);
            var result = _HttpClient.GetAsync(endpoint).Result;
            return GetIntResult(result);
        }

        public int Multiply(int left, int right)
        {
            var endpoint = GetApiEndpoint("multiply", left, right);
            var result = _HttpClient.GetAsync(endpoint).Result;
            return GetIntResult(result);
        }

        public int Divide(int left, int right)
        {
            var endpoint = GetApiEndpoint("divide", left, right);
            var result = _HttpClient.GetAsync(endpoint).Result;
            return GetIntResult(result);
        }
    }
}
