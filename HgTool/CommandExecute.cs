using System;
using System.Diagnostics;

namespace HgTool
{
    public abstract class CommandExecute
    {
        protected string _commandName = "";

        public abstract void ExecuteCommand();

        public string CommandName
        {
            get { return _commandName; }
        }

        protected void ExecuteProcess(string appName, string arguments, string workingDir = "")
        {
            using (var process = new Process
            {
                StartInfo =
                {
                    Arguments = arguments,
                    FileName = appName,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    WorkingDirectory = workingDir
                }
            })
            {
                process.Start();
                process.OutputDataReceived += (sender, args) => Display(args.Data);
                process.BeginOutputReadLine();

                process.WaitForExit();
            }
        }

        private void Display(string input)
        {
            if (input == null || input.Equals(""))
                return;

            if(input.Contains("CHANGED"))
                WriteLineWithColoredLetter(input, "CHANGED", ConsoleColor.Red);
            else if (input.Contains("OK"))
                WriteLineWithColoredLetter(input, "OK", ConsoleColor.Green);
            else
            {
                Console.WriteLine("{0}", input);
            }
        }

        void WriteLineWithColoredLetter(string letters, string c, ConsoleColor color)
        {
            var o = letters.IndexOf(c, StringComparison.Ordinal);
            if (o != -1)
            {
                Console.Write(letters.Substring(0, o));
                Console.ForegroundColor = color;
                int i = 0;
                for (; i < c.Length; i++)
                {
                    Console.Write(letters[o + i]);
                }

                Console.ResetColor();
                Console.WriteLine(letters.Substring(o + i));
            }
            else
            {
                Console.WriteLine(letters);
            }
        }
    }
}