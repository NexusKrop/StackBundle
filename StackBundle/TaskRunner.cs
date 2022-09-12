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
            Console.Write("> 执行任务 :");
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
                    Console.WriteLine("执行任务 {0} 失败。", task.GetName());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   {0}", ex.Message);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("请检查 Bundle 是否正确解压。");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("安装失败（耗时 {0}）", sw.Elapsed);
                    Console.ResetColor();
                    Environment.ExitCode = 1;
                    return;
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("执行任务 {0} 时发生错误。", task.GetName());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("   {0}", ex.ToString());
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("请检查 Bundle 是否正确解压，并且您是否已连接到网络。");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("安装失败（耗时 {0}）", sw.Elapsed);
                    Console.ResetColor();
                    Environment.ExitCode = 1;
                    return;
                }
            }

            Console.WriteLine();
            sw.Stop();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("安装成功（耗时 {0}）", sw.Elapsed);
            Console.ResetColor();
        }
    }
}
