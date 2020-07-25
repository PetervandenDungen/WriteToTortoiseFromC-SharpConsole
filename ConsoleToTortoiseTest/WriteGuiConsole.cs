using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mercurial;
using Mercurial.Gui;

namespace ConsoleToTortoiseTest
{

    class WriteGuiConsole : IMercurialCommand
    {
        public string Command => "WriteToTortoise";

        public IEnumerable<string> Arguments => new string[] { "Can+you+receive+me?" };

        public Collection<string> AdditionalArguments => new Collection<string>();

        public IMercurialCommandObserver Observer => new DebugObserver();

        public int Timeout => 60;

        public void After(int exitCode, string standardOutput, string standardErrorOutput)
        {
            Console.Out.WriteLine($"exitCode: {exitCode}");
            Console.Out.WriteLine($"standardOutput: {standardOutput}");
            Console.Out.WriteLine($"{standardErrorOutput}");
        }

        public void Before()
        {
            //Console.Out.WriteLine($"Before..");
        }

        public void Validate()
        {
            //Console.Out.WriteLine($"Validate..");
        }
    }

    public class CustomDebugObserver : IMercurialCommandObserver
    {
        public void ErrorOutput(string line)
        {
            Console.WriteLine($"ErrorOutput: {line}");
        }

        public void Executed(string command, string arguments, int exitCode, string output, string errorOutput)
        {
            Console.WriteLine($"command: {command}");
            Console.WriteLine($"arguments: {arguments}");
            Console.WriteLine($"exitCode: {exitCode}");
            Console.WriteLine($"output: {output}");
            Console.WriteLine($"errorOutput: {errorOutput}");
        }

        public void Executing(string command, string arguments)
        {
            Console.WriteLine($"command: {command}");
            Console.WriteLine($"arguments: {arguments}");
        }

        public void Output(string line)
        {
            Console.WriteLine($"ErrorOutput: {line}");
        }
    }
}
