namespace HgTool
{
    public class OutgoingChanges : CommandExecute
    {
        public OutgoingChanges(string commandName)
        {
            _commandName = commandName;
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
    }
}