using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TranspilerConsole.classes
{
    class AppDelegate
    {
        public AppDelegate(string filename)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("var cc = cc = cc || {};");
            builder.AppendLine();
            builder.Append("cc.AppDelegate = cc.Application.extend({");
            builder.AppendLine();
            builder.Append("ctor:function () {");
            builder.AppendLine();
            builder.Append("var cc = cc = cc || {};");
            builder.AppendLine();
            builder.Append(" this._super();");
            builder.AppendLine();
            builder.Append(" },");
            builder.AppendLine();
            builder.Append("initInstance:function () {");
            builder.AppendLine();
            builder.Append(" return true;");
            builder.AppendLine();
            builder.Append("},");
            builder.AppendLine();
            builder.Append("applicationDidFinishLaunching:function () {");
            builder.AppendLine();
            builder.Append("var pDirector = cc.Director.sharedDirector();");
            builder.AppendLine();
            builder.Append("var pScene = "+ filename +".scene();");
            builder.AppendLine();
            builder.Append("pDirector.runWithScene(pScene);");
            builder.AppendLine();
            builder.Append("return true;");
            builder.AppendLine();
            builder.Append("},");
            builder.AppendLine();
            builder.Append("applicationDidEnterBackground:function () {");
            builder.AppendLine();
            builder.Append("cc.Director.sharedDirector().pause();");
            builder.AppendLine();
            builder.Append("},");
            builder.AppendLine();
            builder.Append("applicationWillEnterForeground:function () {");
            builder.AppendLine();
            builder.Append("cc.Director.sharedDirector().resume();");
            builder.AppendLine();
            builder.Append("}");
            builder.AppendLine();
            builder.Append("});");
            builder.AppendLine();
            classes.CreateFolder cf = new classes.CreateFolder();
            string path = cf.getCreateFolder();
            string str = "" + path + "\\AppDel.js";
            File.WriteAllText(""+ path +"\\AppDelegate.js",builder.ToString());
            
        }
    }
}
