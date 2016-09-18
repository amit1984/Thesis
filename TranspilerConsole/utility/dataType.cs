using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class dataType
    {
        public string dataType1(string str)
        {
            Dictionary<string, string> dt = new Dictionary<string, string>();
            dt.Add("auto", "var");
            dt.Add("->", ".");
            foreach (KeyValuePair<string, string> pair in dt)
            {
                str = str.Replace(pair.Key, pair.Value);
            }
            return str;
            
        }

    }
}
