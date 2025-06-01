using System;

namespace uwuzu_client;

class uwuzu_client
{
    static void Main(string[] args)
    {
        // GitHub Copilotありがとう

        string? apiKey = null;
        string? serverUrl = null;

        if (args.Length == 0)
        {
            Console.WriteLine("コマンドライン引数はありません。");
        }
        else
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("/apikey", StringComparison.OrdinalIgnoreCase))
                {
                    if (i + 1 < args.Length)
                    {
                        apiKey = args[i + 1];
                        i++; // APIキーの値を取得済みのため次のループはスキップ
                    }
                    else
                    {
                        Console.WriteLine("APIキーが指定されていません。");
                    }
                }
                else if (args[i].Equals("/server", StringComparison.OrdinalIgnoreCase))
                {
                    if (i + 1 < args.Length)
                    {
                        serverUrl = args[i + 1];
                        i++; // サーバーURLの値を取得済みのため次のループはスキップ
                    }
                    else
                    {
                        serverUrl = "uwuzu.net ";
                        Console.WriteLine("サーバーURLが指定されていません。");
                    }
                }
                else
                {
                    Console.WriteLine($"不明な引数： {args[i]}");
                }
            }

            if (apiKey is not null)
            {
                Console.WriteLine($"API鍵: {apiKey}");
            }

            if (serverUrl is not null)
            {
                Console.WriteLine($"サーバーURL: {serverUrl}");
            }
        }
    }
}