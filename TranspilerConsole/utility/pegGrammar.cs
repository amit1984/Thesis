using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TranspilerConsole.utility
{
    class pegGrammar
    {
        static int peg = 0;
        static string layer ="";
        static string concat = "";
       public string pegGrammarstr(string  str)
       {
           // Scene* HelloWorld::createScene()
          
           Regex regex = new Regex(("Scene\\* (.*)::createScene()"));
           var v = regex.Match(str);
           string s = v.Groups[1].ToString();
           if (!string.IsNullOrEmpty(s))
           {
               string st = s + ".scene = function()";
               layer = " }\n}); \n\n"+ s+".layer = function() { \n var pRet = new "+ s +"() \n pRet.init(); \n return pRet; \n}";
               peg++;
               return st;
           }

           // bool AppDelegate::ApplicationDidFinished()
           Regex regex1 = new Regex(("bool AppDelegate::(.*)"));
           var v1 = regex1.Match(str);
           string s1 = v1.Groups[1].ToString();
           if (!string.IsNullOrEmpty(s1))
           {
               string st1 = s1 + ":function()";
               peg++;
               return st1;
           }

           //bool HelloWorld::init()
           Regex regex2 = new Regex(("bool (.*)::init()"));
           var v2 = regex2.Match(str);
           string s2 = v2.Groups[1].ToString();
           if (!string.IsNullOrEmpty(s2))
           {
               string st2 =  "var " +s2+ "= cc.LayerColor.extend({ \n init:function()";
               peg++;

               return st2;
           }

           Regex regex6 = new Regex(("#include|USING_NS_CC"));
           Match match = regex6.Match(str);
           if (match.Success)
           {
               return "//Commented unnecessary translation";
           }

           Regex regex7 = new Regex(("//"));
           Match match7 = regex7.Match(str);
           if (match7.Success)
           {
               return str;
           }

          
           //Layer anomility
           Regex regex3 = new Regex(("return true;"));
           Match match2 = regex3.Match(str);
           if (match2.Success)
           {
               peg++;
               return "return true;";
           }

           //Layer  check
           Regex regex5 = new Regex("auto (.*) (=) (.*)::create();");
           var v3 = regex5.Match(str);
           string s3 = v3.Groups[1].ToString();
           if (!string.IsNullOrEmpty(s3))
           {
               string st2 = "var " + v3.Groups[1].ToString() + " = " + v3.Groups[3].ToString() + ".layer();";
               return st2;
           }

           Regex regex11 = new Regex(("(.*)->setPosition(Vec2::ZERO);"));
           var v11 = regex11.Match(str);
           string s11 = v11.Groups[1].ToString();
           if (!string.IsNullOrEmpty(s11))
           {
               return "menu.setPositioncc(ccp(0,0));";
           }

           Regex regex12 = new Regex(("void AppDelegate::(.*)() {"));
           var v12 = regex12.Match(str);
           string s12 = v12.Groups[1].ToString();
           if (!string.IsNullOrEmpty(s12))
           {
               string st12 = s12+":function () {";
               return st12;
           }

          // Regex regex13 = new Regex((@"auto (.*) = Label::createWithTTF\((.*)\,(.*)\,(.*)\)\;"));
           Regex regex13 = new Regex((@"auto (.*) = Label::createWithTTF(.*)\;"));
           var v13 = regex13.Match(str);
           string s13 = v13.Groups[1].ToString();
           string s14 = v13.Groups[2].ToString();
           if (!string.IsNullOrEmpty(s13))
           {
               string st13 = "var "+ s13 +"= cc.LabelTTF.create"+ s14+";";
               return st13;
           }

           Regex regex14 = new Regex((@"auto (.*) = Menu::create\((.*)\, (.*)\)\;"));
           var v14 = regex14.Match(str);
           string s15 = v14.Groups[1].ToString();
           string s16 = v14.Groups[2].ToString();
           if (!string.IsNullOrEmpty(s15))
           {
               string st17 = "var " + s15 + " = cc.Menu.create(" + s16 + ");";
               return st17;
           }

           Regex regex15 = new Regex((@"std::cout<<(.*)\;"));
           var v15 = regex15.Match(str);
           string s17 = v15.Groups[1].ToString();
         //  string s18 = v15.Groups[2].ToString();
           if (!string.IsNullOrEmpty(s17))
           {
               string st17 = "console.log("+ s17 +");";
               return st17;
           }

           //Regex regex16 = new Regex((@"for((.*) (.*) = 0;(.*)<(.*);(.*)(.*)(.*)"));
           //var v16 = regex16.Match(str);
           //string s18 = v16.Groups[1].ToString();
           ////  string s18 = v15.Groups[2].ToString();
           //if (!string.IsNullOrEmpty(s18))
           //{
           //    string st17 = "console.log(" + s17 + ");";
           //    return st17;
           //}

           //Regex regex9 = new Regex("menu->setPosition(Vec2::ZERO);");
           //var v9 = regex9.Match(str);
           //string s9 = v9.Groups[1].ToString();
           //if (!string.IsNullOrEmpty(s9))
           //{
           //    string st2 = "menu.setPositioncc(ccp(0,0));";
           //    return st2;
           //}


           if (peg == 3)
           {
               peg = 0;
               return layer;
           }
           
           return "";

       }
      
    }
}
