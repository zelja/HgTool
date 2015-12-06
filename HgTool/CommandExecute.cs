using System.Diagnostics;

namespace HgTool
{
    public abstract class CommandExecute
    {
        public abstract void ExecuteCommand();

        public string CommandName
        {
            get;
            set;
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
                process.OutputDataReceived += (sender, args) => CommandOut(args.Data);
                process.BeginOutputReadLine();

                process.WaitForExit();
            }
        }

        protected abstract void CommandOut(string commandOut);
    }
}