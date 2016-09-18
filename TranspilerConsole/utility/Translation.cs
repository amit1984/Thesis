using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class Translation
    {
        public string getTranslatedData(string type,string name)
        {
            DataSet initalvalueScalar = new DataSet();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string docPath = path + "Data\\Translation.xml";
            initalvalueScalar.ReadXml(docPath);
            for (int i = 0; i < initalvalueScalar.Tables[0].Rows.Count; i++)
            {
                if (((string.Compare(initalvalueScalar.Tables[0].Rows[i]["type"].ToString(), type) == 0) && (string.Compare(initalvalueScalar.Tables[0].Rows[i]["name"].ToString(), name) == 0)) || (name.Contains("::")))
                {
                    if (name.Contains("::"))
                    {
                        string[] arr = Regex.Split(name, @"\::");
                        string str = " cc." + arr[0] + "." + arr[1];
                        return str;
                    }
                    else
                    {
                        if (Convert.ToInt32(initalvalueScalar.Tables[0].Rows[i]["weight"].ToString()) >= 1)
                        {
                            return initalvalueScalar.Tables[0].Rows[i]["tranName"].ToString();
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
            return name;
        }
    }
}
