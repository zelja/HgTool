using System;

namespace HgTool
{
    public class ModifiedFiles : CommandExecute
    {
        public ModifiedFiles(string commandName)
        {
            _commandName = commandName;
        }
        public override void ExecuteCommand()
        {
            string appName = "hg.exe";
            string command = "status -m";
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
    }
}