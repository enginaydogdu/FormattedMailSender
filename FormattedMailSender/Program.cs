using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattedMailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Mail mail = new Mail();
            mail.SendMail("engin_87@msn.com");

        }
    }
}
