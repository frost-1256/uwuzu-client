using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace uwuzu_client
{

    public static class CommandExtensions
    {
        /// <summary>
        /// なんなんこれ
        /// <summary>
        public class Data1
        {
            public required string username { get; set; }
            public required string userid { get; set; }
            public int followee_cnt { get; set; }
            public int follower_cnt { get; set; }
        }
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
                string me_data = await response.Content.ReadAsStringAsync();
                var me_data_deserialized = JsonSerializer.Deserialize<Data1>(me_data);
                if (response.IsSuccessStatusCode)
                {
                    return string.Format("あなたの名前: {0} \nユーザー名: {1} \nフォロー中: {2} / フォロワー: {3}",
                        me_data_deserialized.username, me_data_deserialized.userid, me_data_deserialized.followee_cnt, me_data_deserialized.follower_cnt);
                }
                else
                {
                    throw new HttpRequestException($"サーバーからの応答が無効です: {response.StatusCode}");
                }
            }
        }
        public static async Task<string> ueuse(this string command, string serverUrl, string apiKey, string content)
        {
            if (string.IsNullOrEmpty(serverUrl) || string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("サーバーURLまたはAPIキーが無効です。");
            }

            using (HttpClient client = new HttpClient())
            {
                string requestUrl = "https://" + serverUrl + "/api/ueuse/create?token=" + apiKey + "&text=" + content;
                HttpResponseMessage response = await client.PostAsync(requestUrl, null);
                //HttpResponseMessage response = await client.PostAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    return string.Format("送信完了しました！");
                }
                else
                {
                    throw new HttpRequestException($"サーバーからの応答が無効です: {response.StatusCode}");
                }
            }
        }
    }
}
