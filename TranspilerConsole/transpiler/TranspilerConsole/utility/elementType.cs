using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class elementType
    {
        public string elementType1(string str)
        {
            Dictionary<string, string> dt = new Dictionary<string, string>();
            dt.Add("MenuItemFont::create", "cc.MenuItemFont.create");
            dt.Add("Menu::create", "cc.Menu.create");
            dt.Add("Vec2", "cc.ccp");
            foreach (KeyValuePair<string, string> pair in dt)
            {
                str = str.Replace(pair.Key, pair.Value);
            }
            return str;

        }

    }
}
