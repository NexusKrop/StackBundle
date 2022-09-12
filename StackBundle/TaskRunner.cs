using System;
using System.Diagnostics;
using StackBundle.Tasks;

namespace StackBundle
{
    public class TaskRunner
    {
        public static readonly ITask[] Tasks =
        {
            new InitTask(),
            new VerifyTask(),
            new PaperTask(),
            new SetupServerTask()
        };

        public void Run(ITask task)
        {
            var name = task.GetName();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("> Task :");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(name);
            Console.ForegroundColor = ConsoleColor.Gray;
            task.Run();
        }

        public void RunTasks()
        {
            var sw = new Stopwatch();
            sw.Start();

            foreach (var task in Tasks)
            {
                try
                {
                    Run(task);
                }
                catch (TaskFailureException ex)
                {
                    sw.Stop();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Failed to run task {0}.", task.GetName());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   {0}", ex.Message);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Please check if the bundle was extracted correctly.");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Installation Failed in {0}", sw.Elapsed);
                    Console.ResetColor();
                    Environment.ExitCode = 1;
                    return;
                }
            }

            Console.WriteLine();
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Installation Succeeded in {0}", sw.Elapsed);
            Console.ResetColor();
        }
    }
}
