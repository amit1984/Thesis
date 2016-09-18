var a =5;
var b =4;
if (a >b){
largest =a;
}else if (b >a){
largest =b;
}else {
console.log("Uh oh, they're the same!\n");
}

(a <b)? a : 

void  cc.MainScene.startEditMode(EditMode editMode
{
switch (editMode
{
case 
_editor>startEditMode(_editModeCabinet);
return;

case 
_editor>startEditMode(_editModeBackground);
return;

case 
_editor>startEditMode(_editModeScale);
return;

case 

CCASSERT(false,"Unknown edit mode ...");
return;
}
}


while(j>10)
{

}

for(var i;i<10;i++)
{
console.log("amit");
}

var j =0;

//Commented unnecessary translation

//Commented unnecessary translation

HelloWorld.scene = function()
{
    // 'scene' is an autorelease object
var scene = cc.Scene.create();

    // 'layer' is an autorelease object
var layer = HelloWorld.layer();

    // add layer as a child to scene
scene>addChild(layer);

    // return the scene
return scene;
}

// on "init" you need to initialize your instance
var HelloWorld= cc.LayerColor.extend({ 
 init:function()
{
    //////////////////////////////
    // 1. super init first
//
{
//
}

    //   var size = cc.Director.sharedDirector().getWinSize();
    //   CCSize winSize = CCDirector::sharedDirector()->getWinSize();

var visibleSize = cc.Director.getInstance()>getVisibleSize();
cc.ccp origin = cc.Director.getInstance()>getVisibleOrigin();

    /////////////////////////////
    // 2. add a menu item with "X" image, which is clicked to quit the program
    //    you may modify it.

    // add a "close" icon to exit the progress. it's an autorelease object
var closeItem = cc.MenuItemImage.create("CloseNormal.png","CloseSelected.png",this.menuCallback,this);
//
//
//

closeItem>setPosition(cc.ccp(origin.x +visibleSize.width closeItem>getContentSize().width/2 
origin.y +closeItem>getContentSize().height/2));

    // create menu, it's an autorelease object
var menu = cc.Menu.create(closeItem);
menu>setPosition( cc.Vec2.ZERO);
this>addChild(menu,1);

for(var i;i<10;i++
{
console.log("amit");
}

    /////////////////////////////
    // 3. add your codes below...

    // add a label shows "Hello World"
    // create and initialize a label

var label= cc.LabelTTF.create("Hello World", "fonts/Marker Felt.ttf", 24);

    // position the label on the center of the screen
label>setPosition(cc.ccp(origin.x +visibleSize.width/2
origin.y +visibleSize.height label>getContentSize().height));

    // add the label as a child to this layer
this>addChild(label,1);

    // add "HelloWorld" splash screen"
var sprite = cc.Sprite.create("HelloWorld.png");

    // position the sprite on the center of the screen
sprite>setPosition(cc.ccp(visibleSize.width/2 +origin.x,visibleSize.height/2 +origin.y));

    // add the sprite as a child to this layer
this>addChild(sprite,0);

return true;
 }
}); 

HelloWorld.layer = function() { 
 var pRet = new HelloWorld() 
 pRet.init(); 
 return pRet; 
}


//
{
 cc.Director.getInstance()>end();

//
//

}





