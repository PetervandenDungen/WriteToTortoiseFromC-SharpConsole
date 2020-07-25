using Mercurial;
using Mercurial.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleToTortoiseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Mercurial.Repository repo = new Repository(@"C:\Users\vddungenpeter\source\repos\Test");

            RevSpec working = repo.Identify();

            //foreach (var changeSet in repo.Log())
            //{
            //    Console.WriteLine(changeSet);
            //    if (changeSet.Revision == working)
            //    {
            //        Console.WriteLine("*** Working changeset!");
            //    }
            //}



            //Mercurial.Gui.GuiClient.ClientType = GuiClientType.PyQT;
            var cmd = new WriteGuiConsole();
            Mercurial.Client.SetClientPath(@"C:\Program Files\TortoiseHG");
            if (Client.CouldLocateClient)
            {
                repo.Execute(cmd);
                //Client.Execute(new RevertCommand());
            }

            //Mercurial.Gui.GuiClient.InitGui(repo);
            Console.ReadLine();
        }
    }
}
