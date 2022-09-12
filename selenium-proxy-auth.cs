/*
https://www.facebook.com/hkvn9x
skype: nttrung9x
https://mmo69.com
telegram: hkvn9x
*/
string Proxy = "123.123.123.789:9789";

ChromeOptions options = new ChromeOptions();

options.AddArgument("--proxy-server=" + Proxy);

options.AddArgument("load-extension=extension_proxy_auth");

ChromeDriver chrome = new ChromeDriver(options);

=====================

Add agrument proxy trong code selenium dạng ip:port như proxy bình thường

change user và pass ProxyAouth vào background.js nữa là xong

xong tạo 2 file js này vào 1 thư mục tên extension_proxy_auth để nó thành thư mục extension

load thư mục extension vừa tạo là xong

# background.js

var Global = {

    currentProxyAouth: {
    
        username: 'xxx',
	
        password: 'xxx'
	
    }
    
}

chrome.webRequest.onAuthRequired.addListener(

    function(details, callbackFn) {
    
        console.log('onAuthRequired >>>: ', details, callbackFn);
	
		//alert(Global.currentProxyAouth.username);
		
        callbackFn({
	
            authCredentials: Global.currentProxyAouth
	    
        });
	
    }, {
    
        urls: ["<all_urls>"]
	
    }, ["asyncBlocking"]);

chrome.runtime.onMessage.addListener(

    function(request, sender, sendResponse) {
    
        console.log('Background recieved a message: ', request);
	
        POPUP_PARAMS = {};
	
        if (request.command && requestHandler[request.command])
	
        {
	
            requestHandler[request.command](request);
	    
        }
	
    }
    
);

# =====================
# manifest.json
{
	"version": "1.0.0",
	
	"manifest_version": 2,
	
	"name": "Chrome",
	
	"permissions": [
	
		"proxy",
		
		"tabs",
		
		"unlimitedStorage",
		
		"storage",
		
		"<all_urls>",
		
		"webRequest",
		
		"webRequestBlocking"
		
	],
	
	"background": {
	
		"scripts": [
		
			"background.js"
			
		]
		
	},
	
	"minimum_chrome_version": "22.0.0"
	
}
