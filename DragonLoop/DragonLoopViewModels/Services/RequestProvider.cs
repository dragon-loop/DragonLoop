using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DragonLoopViewModels.Services
{
    public static class RequestProvider
    {
        // Only one HttpClient is instantiated per application
        private static readonly HttpClient HttpClient = new HttpClient();

        public static async Task<TResult> GetAsync<TResult>(string uri)
        {
            HttpResponseMessage response = await HttpClient.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }

            string serialized = await response.Content.ReadAsStringAsync();

            TResult result = await Task.Run(() =>
                JsonConvert.DeserializeObject<TResult>(serialized));

            return result;
        }
    }
}
