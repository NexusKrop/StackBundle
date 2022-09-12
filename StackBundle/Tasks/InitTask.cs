using System;
using System.IO;
using IniParser;

namespace StackBundle.Tasks
{
    public class InitTask : ITask
    {
        public string GetName()
        {
            return "init";
        }

        public void Run()
        {
            if (!File.Exists("StackBundle.ini"))
            {
                throw new TaskFailureException("Bundle metadata not found.");
            }

            var parser = new FileIniDataParser();
            Common.IniData = parser.ReadFile("StackBundle.ini");
        }
    }
}
