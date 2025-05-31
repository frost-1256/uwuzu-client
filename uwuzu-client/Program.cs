namespace uwuzu_client;

class uwuzu_client
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("コマンドライン引数はありません。");
        }
        else
        {
            foreach (string arg in args)
                Console.WriteLine(arg);
        }
    }
}