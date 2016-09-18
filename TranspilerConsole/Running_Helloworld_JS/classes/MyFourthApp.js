
var MyFourthApp = cc.LayerColor.extend({
 init:function()
{

        this.initWithColor(cc.ccc4(0,0,0,255));
        var size = cc.Director.sharedDirector().getWinSize();

        cc.AudioManager.sharedEngine().setEffectsVolume(0.5);
        cc.AudioManager.sharedEngine().setBackgroundMusicVolume(0.5);

        var menuItemFirst = new cc.MenuItemFont.create("Hello World",this,this.playSound);

        menuItemFirst.setPosition(cc.ccp(size.width/2,size.height/2+50));

        var menuCenter = cc.Menu.create(menuItemFirst);
        menuCenter.setPosition(cc.ccp(0,0));

        this.addChild(menuCenter);


return this;
  },
    playSound:function(){
        cc.Log("Playing sound");
        cc.AudioManager.sharedEngine().playEffect("resources/effect2");
    }
});
MyFourthApp.scene = function() {
var scene = cc.Scene.create();
var layer = MyFourthApp.layer();
scene.addChild(layer);
return scene;
}
MyFourthApp.layer = function() {
var pRet = new MyFourthApp();
if(pRet && pRet.init()){
return pRet;
}
return null;
}