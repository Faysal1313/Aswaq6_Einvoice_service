using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aswaq6_Einvoice
{
    class load_main
    {
       static public void load_basec_Data()
        {
        
            v.txt_id = db.id;

            v.txt_secret = db.secret;

            v.txt_activity = db.GetData("select cActivityCode from  DataSet").Rows[0][0].ToString().Trim();
            v.pinToken = db.pinToken;

            v.Round = 5;

            if (db.pinToken == "" || db.pinToken == " ")
            {
                v.have_token = false;
            }
            else
            {
                v.have_token = true;
            }
          

            db.log_error("تم تحميل المعلومات الرئيسية بشكل سليم وصحيح ....load basic data Successfully ");
        }
    }
}
