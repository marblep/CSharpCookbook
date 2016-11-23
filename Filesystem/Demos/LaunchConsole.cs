using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCookbook.Src.Filesystem.Demos
{
    class LaunchConsole : BaseApp
    {
        public override int GetPriority() { return 9; }

        public override void Run()
        {
            Process application = new Process();
            // Run the command shell.
            application.StartInfo.FileName = @"cmd.exe";
            // Turn on command extensions for cmd.exe.
            application.StartInfo.Arguments = "/E:ON";
            application.StartInfo.RedirectStandardInput = true;
            application.StartInfo.UseShellExecute = false;
            application.Start();
            StreamWriter input = application.StandardInput;
            // Run the command to display the time.
            input.WriteLine("TIME /T");
            // Stop the application we launched.
            input.WriteLine("exit");

            Console.ReadKey();
        }
    }
}
