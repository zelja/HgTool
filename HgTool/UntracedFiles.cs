using System;
using System.Text.RegularExpressions;

namespace HgTool
{
    public class UntracedFiles : CommandExecute
    {
        public UntracedFiles(string commandName)
        {
            _commandName = commandName;
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

        private void RegexTest(string input)
        {
            string regEx = @"^.*\.(cs|csproj)$";
            string[] array = input.Split('\n');
            MatchCollection mc;
            foreach (var it in array)
            {
                mc = Regex.Matches(it, regEx);
                foreach (Match match in mc)
                {
                    Console.WriteLine("\t {0}", match);
                }
            }
        }
    }
}