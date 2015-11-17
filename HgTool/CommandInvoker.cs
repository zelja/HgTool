using System.Collections;
using System.Linq;

namespace HgTool
{
    public class CommandInvoker
    {
        private readonly ArrayList _commandList = new ArrayList();

        public CommandInvoker()
        {
            _commandList.Add(new OutgoingChanges("outgoing"));
            _commandList.Add(new ModifiedFiles("modified"));
            _commandList.Add(new UntracedFiles("untracked"));
            _commandList.Add(new IncomingChanges("incoming"));
        }

        public CommandExecute GetCommandExecute(string commandName)
        {
            return _commandList.Cast<CommandExecute>().FirstOrDefault(commandExecute => commandExecute.CommandName == commandName);
        }
    }
}