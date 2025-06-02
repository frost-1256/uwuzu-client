using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace uwuzu_client
{
    public static class CommandExtensions
    {
        public static async Task<string> getme(this string command, string serverUrl, string apiKey)
        {
            if (string.IsNullOrEmpty(serverUrl) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("�T�[�o�[URL�܂���API�L�[�������ł��B");
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
                    throw new HttpRequestException($"�T�[�o�[����̉����������ł�: {response.StatusCode}");
                }
            }
        }
        public static async Task<string> ueuse(this string command, string serverUrl, string apiKey, string content)
        {
            if (string.IsNullOrEmpty(serverUrl) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("�T�[�o�[URL�܂���API�L�[�������ł��B");
            }

            using (HttpClient client = new HttpClient())
            {
                string requestUrl = "https://" + serverUrl + "/api/ueuse/create?token=" + apiKey + "&text=" + content;
                HttpResponseMessage response = await client.PostAsync(requestUrl, null);
                //HttpResponseMessage response = await client.PostAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    return string.Format("���M�������܂����I");
                }
                else
                {
                    throw new HttpRequestException($"�T�[�o�[����̉����������ł�: {response.StatusCode}");
                }
            }
        }
    }
}
