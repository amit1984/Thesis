using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranspilerConsole.TInterface;

namespace TranspilerConsole.classes
{
    class NotificationSender
    {
        public ICalculator ObjCal = null;

        public NotificationSender(ICalculator tmpService)
        {
            ObjCal = tmpService;
        }
        //Injection through property  
        public void SendNotification()
        {
            Console.WriteLine(ObjCal.Add(3, 3));
        }  
    }
}
