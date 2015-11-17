using System;

namespace HgTool
{
    class Program
    {
        private static void PrintMenu()
        {
            Console.WriteLine("1 - Untracked files.");
            Console.WriteLine("2 - Modified files.");
            Console.WriteLine("3 - Incoming changes.");
            Console.WriteLine("4 - Outgoing changes.");
            Console.WriteLine("5 - Create bundle.");
            Console.WriteLine("q - Exit.");
        }

        static string GetCommandName(string input)
        {
            switch (input)
            {
                case "1":
                    return "untracked";
                case "2":
                    return "modified";
                case "3":
                    return "incoming";
                case "4":
                    return "outgoing";
                case "5" :
                    return "bundle";
                default:
                    return "";
            }
        }

        static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException("args");

            Console.WriteLine("Please enter valid operation:");
            string input = "";
            do
            {
                PrintMenu();
                input = Console.ReadLine();

                string commandName = GetCommandName(input);
                if (commandName.Equals(""))
                    continue;

                var command = new CommandInvoker();
                CommandExecute cmd = command.GetCommandExecute(commandName);
                if (cmd != null)
                    cmd.ExecuteCommand();

            } while (input != "quit" && input != "q");
        }
    }
}
