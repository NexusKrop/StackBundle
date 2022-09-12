using System;
using System.IO;

namespace StackBundle
{
    class MainClass
    {
        private static readonly string[] Banner = {
            @" ________  _________  ________  ________  ___  __    ________  ___  ___  ________     ",
            @"|\   ____\|\___   ___\\   __  \|\   ____\|\  \|\  \ |\   __  \|\  \|\  \|\   ___  \   ",
            @"\ \  \___|\|___ \  \_\ \  \|\  \ \  \___|\ \  \/  /|\ \  \|\  \ \  \\\  \ \  \\ \  \   ",
            @" \ \_____  \   \ \  \ \ \   __  \ \  \    \ \   ___  \ \   ____\ \  \\\  \ \  \\ \  \  ",
            @"  \|____|\  \   \ \  \ \ \  \ \  \ \  \____\ \  \\ \  \ \  \___|\ \  \\\  \ \  \\ \  \ ",
            @"    ____\_\  \   \ \__\ \ \__\ \__\ \_______\ \__\\ \__\ \__\    \ \_______\ \__\\ \__\",
            @"  |\_________\   \|__|  \|__|\|__|\|_______|\|__| \|__|\|__|     \|_______|\|__| \|__|",
            @"  \|_________|  "
        };

        private static readonly string[] Copyright =
        {
            "PaperMC copyright (C) PaperMC Team & contributors.",
            "StackPun copyright (C) NexusKrop project."
        };

        internal static readonly TaskRunner Runner = new TaskRunner();

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            foreach (var str in Banner)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var cpr in Copyright)
            {
                Console.WriteLine(cpr);
            }

            Environment.CurrentDirectory = Path.Combine(Environment.CurrentDirectory, "server");

            Runner.RunTasks();
        }
    }
}
