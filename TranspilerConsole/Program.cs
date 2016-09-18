using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranspilerConsole.classes;

namespace TranspilerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            classes.ReadTokens mf2 = new classes.ReadTokens();
            mf2.menuDriven();
            
        }
    }
}
