// Document: https://www.selenium.dev/documentation/webdriver/bidirectional/bidi_api/

// Code share By www.VipSoft247.Com
public void RunProfileBy_VipSoft247_Com()
{
    var options = new ChromeOptions {AcceptInsecureCertificates = true};
    options.AddArgument("headless");
    options.Proxy = new Proxy {HttpProxy = "1.1.1.1:12345", SslProxy = "1.1.1.1:12345", Kind = ProxyKind.Manual};
    //options.AddArguments($"--proxy-server=http://1.1.1.1:12345");
    var driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromMinutes(2));

/*
https://www.facebook.com/hkvn9x
skype: nttrung9x
https://mmo69.com
telegram: hkvn9x
*/
    NetworkAuthenticationHandler handler = new NetworkAuthenticationHandler()
    {
        UriMatcher = d => true, //d.Host.Contains("your-host.com")
        Credentials = new PasswordCredentials("proxy_user", "proxy_pass")
    };

    var networkInterceptor = driver.Manage().Network;
    networkInterceptor.AddAuthenticationHandler(handler);
    networkInterceptor.StartMonitoring();

    _driver.Navigate().GoToUrl("https://VipSoft247.Com/");

    networkInterceptor.StopMonitoring();
    driver.Quit();
}
