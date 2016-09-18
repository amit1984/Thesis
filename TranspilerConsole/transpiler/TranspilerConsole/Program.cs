using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using TranspilerConsole.classes;
using TranspilerConsole.services;
using TranspilerConsole.TInterface;

namespace TranspilerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the file name");
            string filename = Console.ReadLine();
            classes.CreateFolder cf = new classes.CreateFolder();
            cf.setCreateFolder();
            classes.AppDelegate ap = new classes.AppDelegate(filename);
            classes.cocos2d cs = new classes.cocos2d(filename);
            classes.MainFile mf = new classes.MainFile(filename);
            classes.ReadTokens mf1 = new classes.ReadTokens();
            ICalculator calculator = new Calculator();
            //calculator.Add(5, 5);
            //calculator.Subtract(6, 5);
            //calculator.Multiply(5, 5);
            //calculator.Divide(10, 5);

            var builder = new ContainerBuilder();
            builder.RegisterType<Calculator>().As<ICalculator>();
            var container = builder.Build();

            Console.WriteLine(container.Resolve<ICalculator>().Add(3, 3));

            NotificationSender ns = new NotificationSender(calculator);
            ns.SendNotification();

            Console.ReadLine();
            
        }
    }
}
