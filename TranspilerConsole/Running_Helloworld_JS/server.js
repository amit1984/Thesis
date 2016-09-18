var express  = require('express');
var app      = express();

app.use('/cocos2d', express.static(__dirname + '/cocos2d') );
app.use('/cocosDenshion', express.static(__dirname + '/cocosDenshion') );
app.use('/classes', express.static(__dirname + '/classes') );
app.use('/resources', express.static(__dirname + '/resources') );

app.get('/', function(req,res){
    res.sendfile('index.html');
    console.log('Sent index.html');
});

app.get('/api/hello', function(req,res){
   res.send('Hello World');
});
app.listen(process.env.PORT || 4000);
console.log('Check.... localhost:4000');