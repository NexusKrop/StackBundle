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
                Console.WriteLine("Server exists, checking checksum...");
                ServerExist();
            }
            else
            {
                Console.WriteLine("Server does not exist.");
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
                Console.WriteLine("Server exists, but not the server we want (corrupted)?");
                Console.WriteLine("Defaulting to invalid server.");
                NoServer();
            }
            else
            {
                Console.WriteLine("Server exists.");
            }
        }
    }
}
