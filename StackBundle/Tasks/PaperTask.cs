using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace StackBundle.Tasks
{
    public class PaperTask : ITask
    {
        public string GetName()
        {
            return "paper";
        }

        public void Run()
        {
            if (File.Exists("server.jar"))
            {
                Console.WriteLine("服务端软件存在，校验中...");
                ServerExist();
            }
            else
            {
                Console.WriteLine("服务端软件不存在");
                NoServer();
            }
        }

        public void NoServer()
        {
            MainClass.Runner.Run(new DownloadServer());
        }

        public static string GetSum(string filePath)
        {
            using (var hasher = HashAlgorithm.Create("SHA256"))
            {
                using (var stream = File.OpenRead(filePath))
                {
                    var hash = hasher.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "");
                }
            }
        }

        private void ServerExist()
        {
            if (!GetSum("server.jar").Equals(Common.IniData["Server"]["ServerHash"], StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("服务端软件被修改或已损坏");
                NoServer();
            }
            else
            {
                Console.WriteLine("服务端校验成功");
            }
        }
    }
}
