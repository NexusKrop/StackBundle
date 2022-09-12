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
                Console.Write("Downloading server... {0}%\r", e.ProgressPercentage);
            };
            client.DownloadFileCompleted += (sender, e) =>
            {
                if (e.Error != null)
                {
                    throw e.Error;
                }

                Console.WriteLine("Successfully downloaded the server software");
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
