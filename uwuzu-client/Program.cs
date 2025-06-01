using System;
using System.Threading.Tasks;

namespace uwuzu_client
{
    class uwuzu_client
    {
        static async Task Main(string[] args)
        {
            // GitHub Copilotありがとう

            string? apiKey = null;
            string? serverUrl = null;

            if (args.Length == 0)
            {
                Console.WriteLine("使用方法 \n/apikeyでuwuzuのAPIキーを指定します。 \n/serverでuwuzuサーバーを指定します。\nexample.comの形式で入力してください。デフォルトはuwuzu.netです ");
                Environment.Exit(1);
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
                            Console.WriteLine("API鍵が指定されていません\n終了します。");
                            Environment.Exit(1);
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
                            Console.WriteLine("サーバーURLが指定されていません。");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"不明な引数： {args[i]}");
                    }
                }

                if (apiKey is null)
                {
                    Console.WriteLine("API鍵が指定されていません\n終了します。");
                    Environment.Exit(1);
                }
                else
                {
                    Console.WriteLine($"API鍵: {apiKey}");
                }
                if (serverUrl is not null)
                {
                    Console.WriteLine($"サーバーが指定されました: {serverUrl}");
                }
                else
                {
                    serverUrl = "uwuzu.net";
                    Console.WriteLine($"現在のサーバー: {serverUrl}");
                }
            }
            Console.Clear();
            Console.WriteLine("uwuzu-CLIクライアント(非公式)へようこそ！");
            Console.WriteLine("開発者: はる(frost-1256)");
            Console.WriteLine($"{serverUrl}へ接続します");
            // HttpClient を利用した GET 要求を非同期で実行
            bool result = await ping_pong.GetRequestAsync(serverUrl);
            if (result)
            {
                Console.WriteLine("サーバーへの接続に成功しました。");
                Console.Clear();
                Console.WriteLine($"{serverUrl}へようこそ！");
                Console.WriteLine("使用方法 \nme: 自分の名前とユーザー名, フォロー中, フォロワーを表示\nhelp: コマンドヘルプを表示\nclear: ログをクリア\nexit: クライアントを終了");
                while (true)
                {
                    Console.Write("> ");
                    string command = Console.ReadLine();
                    Console.WriteLine(command);
                    if (command is null)
                    {
                        Console.WriteLine("コマンドが入力されていません。");
                    }
                    else if (command.Equals("me", StringComparison.OrdinalIgnoreCase))
                    {
                        // ここに "me" コマンドの処理を追加
                        string response = await command.getme(serverUrl, apiKey);
                        Console.WriteLine(response);
                    }
                    else if (command.Equals("help", StringComparison.OrdinalIgnoreCase))
                    {
                        // ここに "me" コマンドの処理を追加
                    }
                    else if (command.Equals("clear", StringComparison.OrdinalIgnoreCase))
                    {
                        // ここに "me" コマンドの処理を追加
                        Console.Clear();
                    }
                    else if (command.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    {
                        // ここに "me" コマンドの処理を追加
                        Console.WriteLine("uwuzu-CLIクライアントを終了します。");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"不明なコマンド: {command}");
                    }
                }
            }
            else
            {
                Console.WriteLine("サーバーへの接続に失敗しました。");
                Environment.Exit(1);
            }
        }
    }
}