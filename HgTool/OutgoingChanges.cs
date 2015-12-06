using System;

namespace HgTool
{
    public class OutgoingChanges : CommandExecute
    {
        public OutgoingChanges(string commandName)
        {
            CommandName = commandName;
        }

        public override void ExecuteCommand()
        {
            ConfigurationReader config = new ConfigurationReader();
            const string appName = @"c:\Program Files\ADMS ContinuousIntegration\NightBuild\scripts\nb.bat";
            const string commandName = " --outgoing";
            string command = "--msbuild" + 
                         " --checkout-path=" + config.CheckoutPath + 
                         " --release=" + config.Release + commandName + 
                         " --milestone=" + config.Milestone + 
                         " --software-type=" + config.SoftwareType + 
                         " --hg-url=" + config.TeamUrl + " " + config.LocalBranchParameters;

            ExecuteProcess(appName, command);
        }

        protected override void CommandOut(string commandOut)
        {
            if (commandOut == null || commandOut.Equals(""))
                return;

            if (commandOut.Contains("CHANGED"))
                WriteLineWithColoredLetter(commandOut, "CHANGED", ConsoleColor.Red);
            else if (commandOut.Contains("OK"))
                WriteLineWithColoredLetter(commandOut, "OK", ConsoleColor.Green);
            else
            {
                Console.WriteLine("{0}", commandOut);
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