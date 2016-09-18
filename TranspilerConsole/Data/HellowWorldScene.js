//Commented unnecessary translation

//Commented unnecessary translation

HelloWorld.scene = function()
{
    // 'scene' is an autorelease object
var scene = cc.Scene.create();

    // 'layer' is an autorelease object
var layer = cc.HelloWorld.create();

    // add layer as a child to scene
scene.addChild(layer);

    // return the scene
return scene;
}

// on "init" you need to initialize your instance
var HelloWorld= cc.LayerColor.extend({ 
 init:function()
{
    //////////////////////////////
    // 1. super init first
amit
{
return false;
}

    //   var size = cc.Director.sharedDirector().getWinSize();
    //   CCSize winSize = CCDirector::sharedDirector()->getWinSize();

Size visibleSize = cc.Director.getInstance().getVisibleSize();
cc.ccp origin = cc.Director.getInstance().getVisibleOrigin();

    /////////////////////////////
    // 2. add a menu item with "X" image, which is clicked to quit the program
    //    you may modify it.

    // add a "close" icon to exit the progress. it's an autorelease object
var closeItem = cc.MenuItemImage.create
"CloseNormal.png"
"CloseSelected.png"
CC_CALLBACK_1( cc.HelloWorld.menuCloseCallback,this));

closeItem.setPosition(cc.ccp(origin.x +visibleSize.width closeItem.getContentSize().width/2 
origin.y +closeItem.getContentSize().height/2));

    // create menu, it's an autorelease object
var menu = cc.Menu.create(closeItem,NULL);
menu.setPosition( cc.Vec2.ZERO);
this.addChild(menu,1);

    /////////////////////////////
    // 3. add your codes below...

    // add a label shows "Hello World"
    // create and initialize a label

var label = cc.Label.createWithTTF("Hello World","fonts/Marker Felt.ttf",24);

    // position the label on the center of the screen
label.setPosition(cc.ccp(origin.x +visibleSize.width/2
origin.y +visibleSize.height label.getContentSize().height));

    // add the label as a child to this layer
this.addChild(label,1);

    // add "HelloWorld" splash screen"
var sprite = cc.Sprite.create("HelloWorld.png");

    // position the sprite on the center of the screen
sprite.setPosition(cc.ccp(visibleSize.width/2 +origin.x,visibleSize.height/2 +origin.y));

    // add the sprite as a child to this layer
this.addChild(sprite,0);

return true;
 }
}); 

HelloWorld.layer = function() { 
 var pRet = new HelloWorld() 
 pRet.init(); 
 return pRet; 
}


void  cc.HelloWorld.menuCloseCallback(Ref*pSender
{
 cc.Director.getInstance().end();

#if (CC_TARGET_PLATFORM ==CC_PLATFORM_IOS
exit(0);

}





//menu->setPosition(Vec2::ZERO);
//Commented unnecessary translation
//
//Commented unnecessary translation
//
////hasiudhaisduhaisud
////////////////
////jhiasdhskadjh
////////////////
//
HelloWorld.scene = function()
//{
//   
//    auto scene = Scene::create();
//    
//    auto layer = HelloWorld::create();
//
//    scene->addChild(layer);
//
//    return scene;
//}
//
var HelloWorld= cc.LayerColor.extend({ 
 init:function()
//{
//   
//
//    Size visibleSize = Director::getInstance()->getVisibleSize();
//    Vec2 origin = Director::getInstance()->getVisibleOrigin();
//
//    auto closeItem = MenuItemImage::create("CloseNormal.png","CloseSelected.png",CC_CALLBACK_1(HelloWorld::menuCloseCallback, this));
//    
//	closeItem->setPosition(Vec2(origin.x + visibleSize.width - closeItem->getContentSize().width/2 ,origin.y + closeItem->getContentSize().height/2));
//
//    auto menu = Menu::create(closeItem, NULL);
//    menu->setPosition(Vec2::ZERO);
//    this->addChild(menu, 1);
//    
//    auto label = Label::createWithTTF("Hello World", "fonts/Marker Felt.ttf", 24);
//    
//    label->setPosition(Vec2(origin.x + visibleSize.width/2,origin.y + visibleSize.height - label->getContentSize().height));
//
//    this->addChild(label, 1);
//
//    auto sprite = Sprite::create("HelloWorld.png");
//
//    sprite->setPosition(Vec2(visibleSize.width/2 + origin.x, visibleSize.height/2 + origin.y));
//
//    this->addChild(sprite, 0);
//    
//    return true;
//}
//
//
//
//
//
//
//
//
//
//
//
//
//
