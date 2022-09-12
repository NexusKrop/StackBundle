using System;
using System.IO;

namespace StackBundle.Tasks
{
    public class SetupServerTask : ITask
    {
        public string GetName()
        {
            return "setupServer";
        }

        public void Run()
        {
            File.WriteAllText("eula.txt", "eula=true");
            File.WriteAllText("server.properties", "enforce-secure-profile=false");
            File.WriteAllText("start.sh", Common.IniData["Server"]["Command"]);
            File.WriteAllText("start.bat", Common.IniData["Server"]["Command"]);
        }
    }
}
