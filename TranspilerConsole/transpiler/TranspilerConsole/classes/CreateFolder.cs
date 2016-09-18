using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TranspilerConsole.classes
{
    class CreateFolder
    {
        public string path = @"D:\cocos2d-js";
        public void setCreateFolder()
        {
           
            try
            {
                if (Directory.Exists(path))
                {
                    Console.WriteLine("The directory {0} already exists.", path);
                }
                else
                {
                    Directory.CreateDirectory(path);
                    Console.WriteLine("The directory {0} was created.", path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
        public string getCreateFolder()
        {
            return path;
        }
    }
}
