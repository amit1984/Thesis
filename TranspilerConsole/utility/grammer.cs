using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class grammer
    {
        public bool checkGrammer(DataTable symbolTable)
        {
            //Example of terminal : keywords and example of non-terminal: Menu,MenuItemFont

            string[] rules = new string[5];
            rules[0] = "keyword|identifier|operator";
            rules[1] = "identifier|operator";

            #region Extended Rules 

            // For non-terminal grammer check 

            for (int i = 0; i < symbolTable.Rows.Count; i++)
            {
               
                string type = Convert.ToString(symbolTable.Rows[i]["type"]);
                string name = Convert.ToString(symbolTable.Rows[i]["name"]);
                bool bo = Lookahead(type, name, i, symbolTable);
                if(!bo)
                {
                    return false;
                }
               
            }

           //if(

            //    string auto = "auto"+" "+ checkAlphnumeric() +"="+

            #endregion 

            return true;

        }

        public bool Lookahead(string type,string name, int i, DataTable symbolTable)
        {
            switch (type)
	        {
                case "keyword": return funKeyword(type,name,i,symbolTable);
                                break;
                case "identifier": return funIdentifier(type, name, i, symbolTable);
                                break;
                default:
                    return true;
            }
        }
        public bool funKeyword(string type,string name, int i, DataTable symbolTable)
        {
            if (string.Compare(name, "auto") == 0)
            {
                if ((string.Compare(Convert.ToString(symbolTable.Rows[i+1]["type"]), "identifier") == 0) && (string.Compare(Convert.ToString(symbolTable.Rows[i + 2]["name"]), "=") == 0))
                {
                   
                    //Console.WriteLine("true grammer for keyword: auto");
                    return true;
                }
                else
                {
                    Console.WriteLine("wrong grammer for keyword: auto");
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
          public bool funIdentifier(string type,string name, int i, DataTable symbolTable)
          {
                // HMM();
                Regex regex = new Regex(@"(\,)|(\;)|(\=)|(-)");
                Match match = regex.Match(Convert.ToString(symbolTable.Rows[i + 1]["name"]));
                if ((string.Compare(Convert.ToString(symbolTable.Rows[i + 1]["type"]), "identifier") == 0) || (string.Compare(Convert.ToString(symbolTable.Rows[i + 1]["type"]), "operator") == 0) || (match.Success))
                {
                    //Console.WriteLine("true grammer for iden: auto");
                    return true;
                }
                else
                {
                    Console.WriteLine("wrong grammer for identifier");
                    return false;
                }

            }
          public void HMM()
          {
              double[,] states = new double[4, 4] { { 0, 1, 0.7, 0.1 }, { 0.1, 0.7, 1, 1 }, { 0.7, 0.7, 0.7, 1 }, { 0, 0, 0, 0.7 } }; //[K I O S][K I O S]
               double[,] initial = new double[1, 4] { { 0, 0, 1, 1 } }; //[K I O S]
               double[,] result = new double[1,4];
               if (states.GetLength(0) == initial.GetLength(1))
               {
                    result = new double[initial.GetLength(0), states.GetLength(1)];
                    for (int i = 0; i < initial.GetLength(0); i++)
                    {
                        for (int j = 0; j < states.GetLength(1); j++)
                        {
                            result[i, j] = 0;
                            for (int k = 0; k < result.GetLength(1); k++) // OR k<b.GetLength(0)
                                result[i, j] = result[i, j] + initial[i, k] * states[k, j];
                        }
                    }
                }
                else
                {
                Console.WriteLine("\n Number of columns in First Matrix should be equal to Number of rows in Second Matrix.");
                Console.WriteLine("\n Please re-enter correct dimensions.");
                }
            }
          
           
        }

    }

