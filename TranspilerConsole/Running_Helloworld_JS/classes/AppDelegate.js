var cc = cc = cc || {};
cc.AppDelegate = cc.Application.extend({
ctor:function () {
var cc = cc = cc || {};
 this._super();
 },
initInstance:function () {
 return true;
},
applicationDidFinishLaunching:function () {
var pDirector = cc.Director.sharedDirector();
var pScene = MyFourthApp.scene();
pDirector.runWithScene(pScene);
return true;
},
applicationDidEnterBackground:function () {
cc.Director.sharedDirector().pause();
},
applicationWillEnterForeground:function () {
cc.Director.sharedDirector().resume();
}
});
