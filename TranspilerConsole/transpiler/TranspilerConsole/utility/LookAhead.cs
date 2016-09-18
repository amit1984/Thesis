using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class LookAhead
    {
        
        public string LookAhead1(string line)
        {
            int i = 0;
            string str1 = AppDomain.CurrentDomain.BaseDirectory;

            //foreach (string str in File.ReadAllLines(str1.Replace("\\bin\\Debug", "")+ "\\Data\\LookAheadData.dat"))
            //{
            //    string[] parts = str.Split(',');
            //    foreach (string part in parts)
            //    {
            //        Console.WriteLine("{0}:{1}",
            //            i,
            //            part);
            //    }
            //    i++; // For demonstration.
            //}

           // Regex regex = new Regex(@"Menu|MenuItemFont");

            string text = System.IO.File.ReadAllText("D:\\HelloWorldScene.cpp");
            Regex regex = new Regex("addChild"); 
            Match match = regex.Match(text);
            if (match.Success)
            {
                text.Replace("this", "that");
            }

            
            //if(flag == 1)
            //{
            //    line = line.Replace(", 1);",");");
            //}
            return line;
        }

        public string LookBehind(string line)
        {
            string str = "";
            return str;
        } 
    }
}
