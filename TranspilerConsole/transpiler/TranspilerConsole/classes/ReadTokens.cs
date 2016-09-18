using System;
using System.Collections.Generic;
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
        public ReadTokens()
        {
            int counter = 0;
            string line;
            string filename = "hhh";

            // Read the file and display it line by line.
            System.IO.StreamReader file =
               new System.IO.StreamReader("D:\\HelloWorldScene.cpp");
               StringBuilder builder1 = new StringBuilder();
               while ((line = file.ReadLine()) != null)
               {
                    Regex regex = new Regex(@"(\#)|using|scene|layer|Scene*|::init()|USING_NS");
                    Match match = regex.Match(line);
                    if (!match.Success)
                    {
                        TranspilerConsole.utility.LookAhead dd2 = new TranspilerConsole.utility.LookAhead();
                        TranspilerConsole.utility.dataType dd = new TranspilerConsole.utility.dataType();
                        TranspilerConsole.utility.elementType dd1 = new TranspilerConsole.utility.elementType();
                        line = dd2.LookAhead1(line);
                        line = dd.dataType1(line);
                        line = dd1.elementType1(line);
                        builder1.Append(line);
                        builder1.AppendLine();
                        Console.WriteLine(line);
                    }
               }
                StringBuilder builder = new StringBuilder();
                builder.Append("var " + filename + " = cc.LayerColor.extend({");
                builder.AppendLine();
                builder.Append(" init:function()");
                builder.AppendLine();
                builder.Append("{");
                builder.AppendLine();
                builder.Append("this.initWithColor(cc.ccc4(0, 0, 0, 255));");
                builder.AppendLine();
                for (int i = 0; i < builder1.Length; i++)
                {
                   
                    builder.Append(builder1[i]);
                }
                builder.AppendLine();
                builder.Append("return this;");
                builder.AppendLine();
                builder.Append("}");
                builder.AppendLine();
                builder.Append("});");
                builder.AppendLine();
                builder.Append("" + filename + ".scene = function() {");
                builder.AppendLine();
                builder.Append("var scene = cc.Scene.create();");
                builder.AppendLine();
                builder.Append("var layer = " + filename + ".layer();");
                builder.AppendLine();
                builder.Append("scene.addChild(layer);");
                builder.AppendLine();
                builder.Append("return scene;");
                builder.AppendLine();
                builder.Append("}");
                builder.AppendLine();
                builder.Append("" + filename + ".layer = function() {");
                builder.AppendLine();
                builder.Append("var pRet = new " + filename + "();");
                builder.AppendLine();
                builder.Append("if(pRet && pRet.init()){");
                builder.AppendLine();
                builder.Append("return pRet;");
                builder.AppendLine();
                builder.Append("}");
                builder.AppendLine();
                builder.Append("return null;");
                builder.AppendLine();
                builder.Append("}");
                classes.CreateFolder cf = new classes.CreateFolder();
                string path = cf.getCreateFolder();
                File.WriteAllText("" + path + "\\" + filename + ".js", builder.ToString());
            

            file.Close();

            // Suspend the screen.
            Console.ReadLine();
        }
    }
}
