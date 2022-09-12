using System;
using System.IO;

namespace StackBundle.Tasks
{
    public class VerifyTask : ITask
    {
        public string GetName()
        {
            return "verify";
        }

        public void Run()
        {
            if (!File.Exists("plugins/StackPun.jar"))
            {
                throw new TaskFailureException("StackPun not found.");
            }
        }
    }
}
