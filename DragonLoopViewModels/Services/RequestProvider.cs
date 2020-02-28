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
            var response = await HttpClient.GetAsync(uri);
            return await GetResponse<TResult>(response);
        }

        public static async Task PutAsync<TPayload>(string uri, TPayload payload)
        {
            var response = await HttpClient.PutAsync(uri, new StringContent(payload.ToString()));
            CheckResponseStatus(response);
        }

        public static async Task<TResult> PostAsync<TResult>(string uri, TResult payload)
        {
            var response = await HttpClient.PostAsync(uri, new StringContent(payload.ToString()));
            return await GetResponse<TResult>(response);
        }

        public static async Task DeleteAsync(string uri)
        {
            var response = await HttpClient.DeleteAsync(uri);
            CheckResponseStatus(response);
        }

        private static async Task<TResult> GetResponse<TResult>(HttpResponseMessage response)
        {
            CheckResponseStatus(response);
            var serialized = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResult>(serialized);
        }

        private static void CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ReasonPhrase.ToString());
            }
        }
    }
}
