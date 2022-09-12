using System;
using System.Net;

namespace StackBundle.Tasks
{
    public class DownloadServer : ITask
    {
        WebClient client = new WebClient();
        private bool running;

        public string GetName()
        {
            return "downloadServer";
        }

        public void Run()
        {
            client.DownloadFileAsync(new Uri(Common.IniData["Server"]["ServerUrl"]), "server.jar");
            client.DownloadProgressChanged += (sender, e) =>
            {
                Console.Write("正在下载服务端... {0}%\r", e.ProgressPercentage);
            };
            client.DownloadFileCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }

                Console.WriteLine("--- 服务端软件下载成功 ----");
                running = false;
            };
            running = true;
            while (running)
            {
                // Pause
            }
        }
    }
}
