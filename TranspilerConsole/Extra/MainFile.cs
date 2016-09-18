using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TranspilerConsole.classes
{
    class MainFile
    {
       public MainFile(string filename)
       {
           StringBuilder builder = new StringBuilder();
           builder.Append("var " + filename + " = cc.LayerColor.extend({");
           builder.AppendLine();
           builder.Append(" init:function()");
           builder.AppendLine();
           builder.Append("{");
           builder.AppendLine();
           builder.Append("this.initWithColor(cc.ccc4(0, 0, 0, 255));");
           builder.AppendLine();
           builder.Append("var size = cc.Director.sharedDirector().getWinSize();");
           builder.AppendLine();
           builder.Append("var myLabel = cc.LabelTTF.create('Hello world',  'Times New Roman',  32,  cc.size(320, 32),  cc.TEXT_ALIGNMENT_LEFT);");
           builder.AppendLine();
           builder.Append("myLabel.setPosition(cc.ccp(size.width/2,size.height/2+50));");
           builder.AppendLine();
           builder.Append("this.addChild(myLabel);");
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
       }

    }
}
