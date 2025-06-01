using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace uwuzu_client
{
    internal class ping_pong
    {
        public static async Task<bool> GetRequestAsync(string serverUrl)
        {
            using HttpClient client = new HttpClient();
            try
            {
                string requestUrl = "https://" + serverUrl + "/api/serverinfo-api";
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラーが発生しました: {ex.Message}");
                return false;
            }
        }
    }
}
