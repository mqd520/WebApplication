using System.Net.Sockets;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ConnectRedis();
        }

        static void ConnectRedis()
        {
            var host = "192.168.44.14";
            var port = 26379;
            var tcpClient = new TcpClient();
            Console.WriteLine($"Connect to {host}:{port}");
            tcpClient.ConnectAsync(host, port);
            var ns = tcpClient.GetStream();
            if (tcpClient.Connected)
            {
                Console.WriteLine($"Connect {host}:{port} Success.");
                while (true)
                {
                    string cmd = Console.ReadLine()!;
                    if (cmd.Equals("exit"))
                    {
                        break;
                    }
                    else
                    {
                        var cmd2 = Transform(cmd);
                        var bytes = System.Text.Encoding.UTF8.GetBytes(cmd2);
                        ns.Write(bytes, 0, bytes.Length);
                        ns.FlushAsync();

                        int time = 0;
                        while (time <= 2000)
                        {
                            if (ns.DataAvailable)
                            {
                                var buf = new byte[tcpClient.Available];
                                ns.Read(buf, 0, buf.Length);
                                var text = Encoding.UTF8.GetString(buf);
                                Console.WriteLine(text);
                                break;
                            }
                            else
                            {
                                time += 100;
                                Thread.Sleep(100);
                            }
                        }
                    }
                }
            }
            else
            {
                ConsoleWriteLineWithColor($"Connect {host}:{port} Failed.", ConsoleColor.Red);
            }

            tcpClient.Dispose();
        }

        static void ConsoleWriteLineWithColor(string value, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(value);
            Console.ForegroundColor = oldColor;
        }

        static string Transform(string cmd)
        {
            var result = "";
            var arr = cmd.Split(" ");
            result += "*" + arr.Length + "\r\n";
            foreach (var item in arr)
            {
                result += "$" + item.Length + "\r\n";
                result += item + "\r\n";
            }
            return result;
        }
    }
}
