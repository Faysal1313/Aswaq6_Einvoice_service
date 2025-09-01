using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Aswaq6_Einvoice
{
    class Heartbeat_calss
    {
      
            private readonly Timer _timer;
            public Heartbeat_calss()
            {
                _timer = new Timer(10000) { AutoReset = true };
                _timer.Elapsed += TimerElapsed;
            }
            private void TimerElapsed(object sender, ElapsedEventArgs e)
            {
            string error = "";
            Einvoice.final_Einvoice(ref error);
        
            if(v.cErrortoken.Contains("CKR_PIN_INCORRECT"))
            {
                db.log_error("رقم التوكين غلط ----وسيتم قفل السيرفيس");
                db.log_error("cErrortoken: " + v.cErrortoken);
                Stop();
            }

            //CKR_PIN_INCORRECT
            if (error!="")
            {
                db.log_error(error);
                return;
            }



           
        }
            public void Start()
            {
                _timer.Start();
                db.log_error("................Start service Lighthouse erp  E-invoice...........");
            }
            public  void Stop()
            {
                _timer.Stop();
                db.log_error(".............Shut down service Lighthouse erp  E-invoice...........");

            }


        

    }
}
