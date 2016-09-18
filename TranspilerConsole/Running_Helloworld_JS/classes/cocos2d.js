var cc = cc = cc || {};
cc.Dir = './';//in relate to the html file or use absolute
cc.loadQue = [];//the load que which js files are loaded
cc.COCOS2D_DEBUG = 2;
cc._DEBUG = 1;
cc._IS_RETINA_DISPLAY_SUPPORTED = 0;
cc.$ = function (x) {
return document.querySelector(x);
};
cc.$new = function (x) {
return document.createElement(x);
};
cc.loadjs = function (filename) {
var script = cc.$new('script');
script.src = cc.Dir + filename;
script.order = cc.loadQue.length;
cc.loadQue.push(script);
script.onload = function () {
if (this.order + 1 < cc.loadQue.length) {
cc.$('head').appendChild(cc.loadQue[this.order + 1]);
}
else {
cc.setup("gameCanvas");
jQuery.get("/api/hello", function(data,textStatus,jqXHR){
cc.Log(data);
});
cc.AudioManager.sharedEngine().init("mp3,ogg");
cc.Loader.shareLoader().onloading = function () {
cc.LoaderScene.shareLoaderScene().draw();
};
cc.Loader.shareLoader().onload = function () {
cc.AppController.shareAppController().didFinishLaunchingWithOptions();
};
cc.Loader.shareLoader().preload([
{type:"bgm", src:"resources/background"},
{type:"effect", src:"resources/effect2"}
]);
}
 };
if (script.order === 0)//if the first file to load, then we put it on the head 
{
cc.$('head').appendChild(script);
}
};
cc.loadjs('cocos2d/platform/CCClass.js');
cc.loadjs('cocos2d/platform/CCCommon.js');
cc.loadjs('cocos2d/platform/platform.js');
cc.loadjs('cocos2d/cocoa/CCGeometry.js');
cc.loadjs('cocos2d/cocoa/CCSet.js');
cc.loadjs('cocos2d/platform/CCTypes.js');
cc.loadjs('cocos2d/cocoa/CCAffineTransform.js');
cc.loadjs('cocos2d/support/CCPointExtension.js');
cc.loadjs('cocos2d/base_nodes/CCNode.js');
cc.loadjs('cocos2d/platform/CCMacro.js');
cc.loadjs('cocos2d/platform/CCConfig.js');
cc.loadjs('cocos2d/textures/CCTexture2D.js');
cc.loadjs('cocos2d/textures/CCTextureCache.js');
cc.loadjs('cocos2d/actions/CCAction.js');
cc.loadjs('cocos2d/actions/CCActionInterval.js');
cc.loadjs('cocos2d/actions/CCActionManager.js');
cc.loadjs('cocos2d/actions/CCActionEase.js');
cc.loadjs('cocos2d/layers_scenes_transitions_nodes/CCScene.js');
cc.loadjs('cocos2d/layers_scenes_transitions_nodes/CCLayer.js');
cc.loadjs('cocos2d/layers_scenes_transitions_nodes/CCTransition.js');
cc.loadjs('cocos2d/sprite_nodes/CCSprite.js');
cc.loadjs('cocos2d/label_nodes/CCLabelTTF.js');
cc.loadjs('cocos2d/text_input_node/CCIMEDispatcher.js');
cc.loadjs('cocos2d/touch_dispatcher/CCTouchDelegateProtocol.js');
cc.loadjs('cocos2d/touch_dispatcher/CCTouchHandler.js');
cc.loadjs('cocos2d/touch_dispatcher/CCTouchDispatcher.js');
cc.loadjs('cocos2d/keypad_dispatcher/CCKeypadDelegate.js');
cc.loadjs('cocos2d/keypad_dispatcher/CCKeypadDispatcher.js');
cc.loadjs('cocos2d/CCDirector.js');
cc.loadjs('cocos2d/CCScheduler.js');
cc.loadjs('cocos2d/CCLoader.js');
cc.loadjs('cocos2d/CCDrawingPrimitives.js');
cc.loadjs('cocos2d/platform/CCApplication.js');
cc.loadjs('cocos2d/platform/CCSAXParser.js');
cc.loadjs('cocos2d/platform/AppControl.js');
cc.loadjs('cocos2d/menu_nodes/CCMenuItem.js');
cc.loadjs('cocos2d/menu_nodes/CCMenu.js');
cc.loadjs('cocosDenshion/SimpleAudioEngine.js');
cc.loadjs('classes/AppDelegate.js');
cc.loadjs('classes/MyFourthApp.js');
