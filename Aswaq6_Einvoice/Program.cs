using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Aswaq6_Einvoice
{
    class Program
    {
          static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat_calss>(s =>
                {
                    s.ConstructUsing(Heartbeat => new Heartbeat_calss());
                    s.WhenStarted(Heartbeat => Heartbeat.Start());
                    s.WhenStopped(Heartbeat => Heartbeat.Stop());

                });
                x.RunAsLocalSystem();
                x.SetServiceName("LightHouse_Services");
                x.SetDisplayName("LightHouse ERP System Service");
                x.SetDescription("Start LightHouse ERP System Einvoice and Signer Documents  1.0.0 - www.add4sas.com");

            });
            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetType());
            Environment.ExitCode = exitCodeValue;

            //string error = "";
            //Einvoice.final_Einvoice(ref error);




        }
    }
}
