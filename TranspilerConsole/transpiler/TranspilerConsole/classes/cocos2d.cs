using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TranspilerConsole.classes
{
    class cocos2d
    {
        public cocos2d(string filename)
        {
            StringBuilder builder = new StringBuilder();         
            builder.Append("var cc = cc = cc || {};");
            builder.AppendLine();

            builder.Append("cc.Dir = './';//in relate to the html file or use absolute");
             builder.AppendLine();
            builder.Append("cc.loadQue = [];//the load que which js files are loaded");
                 builder.AppendLine();
            builder.Append("cc.COCOS2D_DEBUG = 2;");
                 builder.AppendLine();
            builder.Append("cc._DEBUG = 1;");
                 builder.AppendLine();
            builder.Append("cc._IS_RETINA_DISPLAY_SUPPORTED = 0;");
                 builder.AppendLine();
            //html5 selector method
            builder.Append("cc.$ = function (x) {");
                 builder.AppendLine();
                builder.Append("return document.querySelector(x);");
                     builder.AppendLine();
            builder.Append("};");
                 builder.AppendLine();
            builder.Append("cc.$new = function (x) {");
                 builder.AppendLine();
                builder.Append("return document.createElement(x);");
                     builder.AppendLine();
            builder.Append("};");
                 builder.AppendLine();
            builder.Append("cc.loadjs = function (filename) {");
                 builder.AppendLine();
                //add the file to the que
                builder.Append("var script = cc.$new('script');");
                     builder.AppendLine();
                builder.Append("script.src = cc.Dir + filename;");
                     builder.AppendLine();
                builder.Append("script.order = cc.loadQue.length;");
                     builder.AppendLine();
                builder.Append("cc.loadQue.push(script);");
                     builder.AppendLine();


                builder.Append("script.onload = function () {");
                     builder.AppendLine();
                    //file have finished loading,
                    //if there is more file to load, we should put the next file on the head
                    builder.Append("if (this.order + 1 < cc.loadQue.length) {");
                         builder.AppendLine();
                        builder.Append("cc.$('head').appendChild(cc.loadQue[this.order + 1]);");
                             builder.AppendLine();
                        //console.log(this.order);
                    builder.Append("}");
                         builder.AppendLine();
                    builder.Append("else {");
                         builder.AppendLine();
                        builder.Append("cc.setup(\"gameCanvas\");");
                             builder.AppendLine();
                        builder.Append("jQuery.get(\"/api/hello\", function(data,textStatus,jqXHR){");
                             builder.AppendLine();
                            builder.Append("cc.Log(data);");
                                 builder.AppendLine();
                        builder.Append("});");
                             builder.AppendLine();
                        builder.Append("cc.AudioManager.sharedEngine().init(\"mp3,ogg\");");
                             builder.AppendLine();
                        //we are ready to run the game
                        builder.Append("cc.Loader.shareLoader().onloading = function () {");
                             builder.AppendLine();
                            builder.Append("cc.LoaderScene.shareLoaderScene().draw();");
                                 builder.AppendLine();
                        builder.Append("};");
                             builder.AppendLine();
                        builder.Append("cc.Loader.shareLoader().onload = function () {");
                             builder.AppendLine();
                            builder.Append("cc.AppController.shareAppController().didFinishLaunchingWithOptions();");
                                 builder.AppendLine();
                        builder.Append("};");
                             builder.AppendLine();
                        //preload ressources
                        builder.Append("cc.Loader.shareLoader().preload([");
                             builder.AppendLine();
                            builder.Append("{type:\"bgm\", src:\"resources/background\"},");
                                 builder.AppendLine();
                            builder.Append("{type:\"effect\", src:\"resources/effect2\"}");
                                 builder.AppendLine();
                        builder.Append("]);");
                             builder.AppendLine();
                    builder.Append("}");
                         builder.AppendLine();
               builder.Append(" };");
                    builder.AppendLine();
                builder.Append("if (script.order === 0)//if the first file to load, then we put it on the head ");
                     builder.AppendLine();
                builder.Append("{");
                     builder.AppendLine();
                    builder.Append("cc.$('head').appendChild(script);");
                         builder.AppendLine();

                builder.Append("}");
                     builder.AppendLine();
            builder.Append("};");
                 builder.AppendLine();

            builder.Append("cc.loadjs('cocos2d/platform/CCClass.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/CCCommon.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/platform.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/cocoa/CCGeometry.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/cocoa/CCSet.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/CCTypes.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/cocoa/CCAffineTransform.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/support/CCPointExtension.js');");
                         builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/base_nodes/CCNode.js');");
                         builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/CCMacro.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/CCConfig.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/textures/CCTexture2D.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/textures/CCTextureCache.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/actions/CCAction.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/actions/CCActionInterval.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/actions/CCActionManager.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/actions/CCActionEase.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/layers_scenes_transitions_nodes/CCScene.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/layers_scenes_transitions_nodes/CCLayer.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/layers_scenes_transitions_nodes/CCTransition.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/sprite_nodes/CCSprite.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/label_nodes/CCLabelTTF.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/text_input_node/CCIMEDispatcher.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/touch_dispatcher/CCTouchDelegateProtocol.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/touch_dispatcher/CCTouchHandler.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/touch_dispatcher/CCTouchDispatcher.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/keypad_dispatcher/CCKeypadDelegate.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/keypad_dispatcher/CCKeypadDispatcher.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/CCDirector.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/CCScheduler.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/CCLoader.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/CCDrawingPrimitives.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/CCApplication.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/CCSAXParser.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/platform/AppControl.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/menu_nodes/CCMenuItem.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocos2d/menu_nodes/CCMenu.js');");
                builder.AppendLine();
            builder.Append("cc.loadjs('cocosDenshion/SimpleAudioEngine.js');");
                builder.AppendLine();

            // User files
            builder.Append("cc.loadjs('classes/AppDelegate.js');");
                builder.AppendLine();
           // builder.Append("cc.loadjs('classes/MyFourthApp.js');");
             //   builder.AppendLine();

            builder.Append("cc.loadjs('classes/" + filename + ".js');"); // the name should be under ""
            builder.AppendLine();
            classes.CreateFolder cf = new classes.CreateFolder();
            string path = cf.getCreateFolder();
            File.WriteAllText("" + path + "\\cocos2d.js", builder.ToString());
        }
    }
}
