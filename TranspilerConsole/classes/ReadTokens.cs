using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TranspilerConsole.utility;

namespace TranspilerConsole.classes
{
    class ReadTokens
    {
        string fileNameJs = "";
        public void menuDriven()
        {
            int ch = 0; 
            TranspilerConsole.utility.Training train = new TranspilerConsole.utility.Training();
            while (ch != 3)
            {
                Console.WriteLine("Please Enter your choice \n 1. Training the system  \n 2. Reading file by path name for translation.  \n 3. Reading file application folder for translation. \n 4. Exit ");
                ch = Convert.ToInt32(Console.ReadLine());
                string filePath = ""; 
                if (ch == 2)
                {
                    Console.WriteLine("\n Enter the file path along with name");
                    filePath = Console.ReadLine();
                    fileNameJs = Path.GetFileName(filePath);
                    fileNameJs = fileNameJs.Replace(".cpp", ".js");

                }
                switch (ch)
                {
                    case 1: train.TrainData();
                        break;
                    case 2: ReadTokensGrammer(filePath);
                        break;
                    case 3: ReadTokensGrammer(filePath);
                        break;
                    case 4: break;
                    default: Console.WriteLine("This choice doesnot exist please enter a new choice");
                        break;
                }
            }
        }

        public void ReadTokensGrammer(string fileName)
        {
              string path, docPath;
              if (string.IsNullOrEmpty(fileName))
              {
                  path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
                  docPath = path + "Data\\HelloWorldScene.cpp";
              }
              else
              {
                  docPath = fileName;
              }

               int counter = 0;
               string line;
               string filename = "hhh";
              
               System.IO.StreamReader file =
               new System.IO.StreamReader(docPath);
               LexicalAnalysis analyzer = new LexicalAnalysis();
               TranspilerConsole.utility.grammer gr = new TranspilerConsole.utility.grammer();
               TranspilerConsole.utility.Translation tran = new TranspilerConsole.utility.Translation();
               TranspilerConsole.utility.Training train = new TranspilerConsole.utility.Training();
               TranspilerConsole.utility.pegGrammar peg = new TranspilerConsole.utility.pegGrammar();
               TranspilerConsole.utility.specialCases spc = new TranspilerConsole.utility.specialCases();
               int lineno = 0;
               StringBuilder strb = new StringBuilder(); string concat = "";
               while ((line = file.ReadLine()) != null)
               {
                   DataTable symbolTable = new DataTable();
                   symbolTable.Columns.Add("type", typeof(string));
                   symbolTable.Columns.Add("name", typeof(string));
                   TranspilerConsole.utility.Translation tr = new TranspilerConsole.utility.Translation();
                   string str = "";
                   string st = peg.pegGrammarstr(line);
                       if (string.Compare(st, "") != 0)
                       {
                           str = st;
                       }
                       else
                       {
                           try {
                           while (line != "")
                           {

                               line = line.Trim(' ', '\t');
                               string token = analyzer.GetNextLexicalAtom(ref line);
                               if (token != null)
                               {
                                   string[] tok = splitLineString(token);                 // function to split the string into tokens
                                   symbolTable.Rows.Add(tok[0].Trim(), tok[1].Trim());
                                   string c = tok[1].Substring(tok[1].Length - 1);       // For getting the whitespace
                                   if (string.IsNullOrWhiteSpace(c))
                                   {
                                       str = str + tran.getTranslatedData(tok[0].Trim(), tok[1].Trim()) + " ";

                                   }
                                   else
                                   {
                                       str = str + tran.getTranslatedData(tok[0].Trim(), tok[1].Trim());
                                   }

                               }


                           }
                            }
                   catch(Exception ex)
                   {
                   }

                       }

                   str = spc.getSpecialCaseData(str);
                   strb.Append(str);
                   strb.AppendLine();
                   //if (!str.Contains(';'))
                   //{
                   //    if (str.Contains('{') || str.Contains('}') || (string.Compare(str, "") == 0))
                   //    {
                   //    }
                   //    else
                   //    {
                   //        utility.pegGrammar pg = new utility.pegGrammar();
                   //        string ss = pg.pegGrammarstr(str);
                   //        Console.WriteLine("Might be a function name:{0}  ", ss);
                   //    }
                   //}
                   System.Console.Write(str + "\n");
                   System.Console.Write("\n");
                   symbolTable.Rows.Add("l", "l");
                   lineno++;
                   if (!gr.checkGrammer(symbolTable))
                   {
                       Console.WriteLine("Error in line number:" + lineno + "\n");
                   }
               }
                //classes.CreateFolder cf = new classes.CreateFolder();
                //string path = cf.getCreateFolder();
                //File.WriteAllText("" + path + "\\" + filename + ".js", builder.ToString());
               string rem = Path.GetFileName(docPath);
               string  pth = docPath.Replace(rem, "");
               if (string.IsNullOrEmpty(fileNameJs))
               {
                   fileNameJs = "HelloWorldScene.js";
               }
               File.WriteAllText(pth + fileNameJs, strb.ToString());
               Console.ForegroundColor = ConsoleColor.DarkGreen;
               Console.WriteLine("\n Please check the file in the same location as the folder with name:"+ fileNameJs+"\n");
               Console.ForegroundColor = ConsoleColor.Black;
            file.Close();
            
        }
       
        public string[] splitLineString(string line)
        {

            int countcomma = 0;
            char[] cr = line.ToCharArray(); string[] str = new string[100]; int j = 0;
            for (int i = 1; i < cr.Count()-2; i++)
            {
                if ((cr[i] != ','))
                {
                    str[j] = str[j] + cr[i].ToString();
                }
                else
                {
                   
                    
                    countcomma++;
                    if (countcomma == 2)                           // This logic is to get the comma which is generally rejected during the string filtering
                    {
                        str[j] = char.ToString(',');
                    }
                    else
                    {
                        j++;
                        str[j] = str[j] + cr[i + 1].ToString();
                    }
                    

                }
            }
            return str;
        }


    }
}
