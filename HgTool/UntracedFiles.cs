using System;
using System.Text.RegularExpressions;

namespace HgTool
{
    public class UntracedFiles : CommandExecute
    {
        public UntracedFiles(string commandName)
        {
            CommandName = commandName;
        }

        public override void ExecuteCommand()
        {
            string appName = "hg.exe";
            string command = "status -u";
            ConfigurationReader config = new ConfigurationReader();
            string checkoutPath = config.CheckoutPath;
            string xmlFullPath = checkoutPath + "RepositoriesData.xml";

            ConfigurationReader configReader = new ConfigurationReader();

            foreach (var workingDir in configReader.ReadRepositoryConfig(xmlFullPath))
            {
                Console.WriteLine(checkoutPath + workingDir);
                ExecuteProcess(appName, command, checkoutPath + workingDir);
            }
        }

        protected override void CommandOut(string commandOut)
        {
            if (commandOut == null)
                return;

            RegexTest(commandOut);
        }

        private void RegexTest(string input)
        {
            string regEx = @"^.*\.(cs|csproj)$";
            string[] array = input.Split('\n');
            MatchCollection mc;
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var it in array)
            {
                mc = Regex.Matches(it, regEx);
                foreach (Match match in mc)
                {
                    Console.WriteLine("\t {0}", match);
                }
            }

            Console.ResetColor();
        }
    }
}