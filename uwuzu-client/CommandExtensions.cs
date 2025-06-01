using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace uwuzu_client
{
    public static class CommandExtensions
    {
        public static async Task<string> getme(this string command, string serverUrl, string apiKey)
        {
            if (string.IsNullOrEmpty(serverUrl) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("サーバーURLまたはAPIキーが無効です。");
            }

            using (HttpClient client = new HttpClient())
            {
                string requestUrl = "https://" + serverUrl + "/api/me/?token=" + apiKey;
                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new HttpRequestException($"サーバーからの応答が無効です: {response.StatusCode}");
                }
            }
        }
    }
}
