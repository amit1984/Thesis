using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace TranspilerConsole.utility
{
    class Training
    {
        double[,] states = new double[4, 4] { { 0, 0.5,0,1 }, { 0.7, 0.5,0.7,0.7 }, { 0, 0.7 ,0.5 ,0.7 }, {0,0.8,0,0.8} };
        double[,] param = new double[4, 2];

        string[] separator = { ";", "{", "}", "\r", "\n", "\r\n" };

        string[] operators = { " ","+", "-", "*", "/", "%", "&","(",")","[","]",
            "|", "^", "!", "~", "&&", "||",",",
            "++", "--", "<<", ">>", "==", "!=", "<", ">", "<=",
            ">=", "=", "+=", "-=", "*=", "/=", "%=", "&=", "|=",
            "^=", "<<=", ">>=", ".", "[]", "()", "?:", "=>", "??" ,"::"};

        public string[] calculateParam(string name)
        {
            double Kno = (4 / name.Length) > 1 ? 0.1 : (4 / name.Length);
            double ono = (1 / name.Length) > 1 ? 0.1 : (1 / name.Length);
            double sno = (1 / name.Length) > 1 ? 0.1 : (1 / name.Length);
            double ino = (5 / name.Length) > 1 ? 0.1 : (5 / name.Length);

            bool oregB,sregB;

            if (Array.IndexOf(operators, name) > -1) 
            {
                oregB = true; 
            }else
            {
                oregB = false;
            }

             if (Array.IndexOf(separator, name) > -1) 
            {
                sregB = true; 
            }else
            {
                sregB = false;
            }


            double kreg = Regex.Match(name, @"^[a-zA-Z]+$").Success ? 1 : 0;
            double oreg = oregB? 1 : 0;
            double sreg = sregB? 1 : 0; 
            double ireg = Regex.Match(name, @"^[a-zA-Z0-9::]+$").Success ? 1 : 0;

            param[0,0]=Kno; param[0,1]=kreg; param[1,0] = ono; param[1,1] = oreg; param[2,0] = sno; param[2,1] = sreg; param[3,0] = ino; param[3,1] = ireg;
            string[] ret = new string[4];
            if ((Kno > 0.5) && (kreg > 0.5))
            {
                ret[0] = "keyword";
                ret[1] = name;
                ret[2] =Convert.ToString((Kno + kreg) / 2);

                return ret;
                
            }
            else if ((ono > 0.5) && (oreg > 0.5))
            {
                ret[0] = "operator";
                ret[1] = name;
                ret[2] = Convert.ToString((ono + oreg) / 2);

                return ret;

            }
            else if ((sno > 0.5) && (sreg > 0.5))
            {
                ret[0] = "seperator";
                ret[1] = name;
                ret[2] = Convert.ToString((sno + sreg) / 2);

                return ret;

            }

            else
            {
                return ret;
            }
        }
        public int getSplitStringCount(string line)
        {
            char[] cr = line.ToCharArray(); string[] str= new string[100]; int j = 0;
            for (int i = 0; i < cr.Count(); i++)
            {
                if (char.IsLetter(cr[i]))
                {
                    str[j] = str[j] + cr[i].ToString();
                }
                else
                {
                    j++;
                    str[j] = str[j] + cr[i].ToString();

                }
            }
            return j;
        }
        public string[] splitString(string line)
        {
            char[] cr = line.ToCharArray(); string[] str = new string[100]; int j = 0;
            for (int i = 0; i < cr.Count(); i++)
            {
                if (char.IsLetter(cr[i]))
                {
                    str[j] = str[j] + cr[i].ToString();
                }
                else
                {
                    j++;
                    str[j] = str[j] + cr[i].ToString();

                }
            }
            return str;
        }
        public void TrainData()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            TranspilerConsole.utility.Training train = new TranspilerConsole.utility.Training();
            string docPathCpp = path + "TrainingData\\cocosCplus.txt";
            string docPathJs = path + "TrainingData\\cocosJs.txt";
            System.IO.StreamReader cfile = new System.IO.StreamReader(docPathCpp);
            string cline;
            System.IO.StreamReader jfile = new System.IO.StreamReader(docPathJs);
            string jline;

            string[] cstr = new string[1000];
            string[] jstr = new string[1000];
            int c = 0, j = 0, count = 0;
            while ((cline = cfile.ReadLine()) != null)
            {
                cstr[c] = cline;
                c++;
            }
            while ((jline = jfile.ReadLine()) != null)
            {
                jstr[j] = jline;
                j++;
            }
            if (j == c)
            {
                while (count < c)
                {
                    //train.insertData("auto menuItemFirst =  MenuItemFont::create('Hello world');", "var menuItemFirst = new cc.MenuItemFont.create('Hello World')");
                    train.insertData(cstr[count], jstr[count]);
                    count++;
                }
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("System got trained in the Translation.xml file from the folowing files in Data Folder: \n ");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("cocosCplus.txt \n cocosJs.txt");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void writeLogXml(string typeA, string nameA, string tranNameA, int weightA)
        {
            XmlDocument xmlEmloyeeDoc = new XmlDocument();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string docPath = path + "Data\\Translation.xml";
            xmlEmloyeeDoc.Load(docPath);
            XmlElement ParentElement = xmlEmloyeeDoc.CreateElement("Translation");
            XmlElement type = xmlEmloyeeDoc.CreateElement("type");
            type.InnerText = typeA;
            XmlElement name = xmlEmloyeeDoc.CreateElement("name");
            name.InnerText = nameA;
            XmlElement tranName = xmlEmloyeeDoc.CreateElement("tranName");
            tranName.InnerText = tranNameA;
            XmlElement weight = xmlEmloyeeDoc.CreateElement("weight");
            weight.InnerText = Convert.ToString(weightA);
            ParentElement.AppendChild(type);
            ParentElement.AppendChild(name);
            ParentElement.AppendChild(tranName);
            ParentElement.AppendChild(weight);
            xmlEmloyeeDoc.DocumentElement.AppendChild(ParentElement);
            xmlEmloyeeDoc.Save(docPath);

        }

        public void insertData(string line1,string line2)
        {
            string[] l1 = new string[100];
            string[] l2 = new string[100];

            l1 = splitString(line1);
            l2 = splitString(line2);

            int l1count = getSplitStringCount(line1);
            int l2count = getSplitStringCount(line2);

            string[] cp1 = new string[10];
            string[] cp2 = new string[10];

            int i=0;
            int incr = l1count > l2count ? l2count:l1count;
            while (i < incr-1)
            {
                cp1 = calculateParam(l1[i]);
                cp2 = calculateParam(l2[i]);

                if (string.Compare(string.IsNullOrEmpty(cp1[0]) ? "" : cp1[0], string.IsNullOrEmpty(cp2[0]) ? "" : cp2[0]) == 0)
                {
                    if(!string.IsNullOrEmpty(cp1[0]) && !string.IsNullOrEmpty(cp1[1]) && !string.IsNullOrEmpty(cp2[1]))
                    {
                        writeLogXml(cp1[0], cp1[1], cp2[1], Convert.ToInt32(cp1[2]));
                    }
                }

                i++;
            }

        }

    }
}
