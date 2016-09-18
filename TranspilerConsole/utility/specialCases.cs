using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class specialCases
    {
        public string getSpecialCaseData(string name)
        {
            DataSet initalvalueScalar = new DataSet();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");
            string docPath = path + "Data\\specialCases.xml";
            initalvalueScalar.ReadXml(docPath);
            for (int i = 0; i < initalvalueScalar.Tables[0].Rows.Count; i++)
            {
                if (((string.Compare(initalvalueScalar.Tables[0].Rows[i]["mainString"].ToString(), name) == 0)))
                {

                    return initalvalueScalar.Tables[0].Rows[i]["replaceString"].ToString();

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
