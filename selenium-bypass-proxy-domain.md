code C#

```
            string Path_ChromeDriver = Application.StartupPath + "\\selenium-manager\\";
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(Path_ChromeDriver);
            service.HideCommandPromptWindow = true;

            ChromeOptions Option = new ChromeOptions();
            Option.BinaryLocation = Application.StartupPath + "\\browser-114\\chrome.exe";
            Option.AddArgument("disable-infobars");
            Option.AddExcludedArgument("enable-automation");
            Option.AddExcludedArgument("--test-type=webdriver");
            Option.AddExcludedArgument("--disable-background-networking");
            Option.AddExcludedArgument("--disable-default-apps");
            Option.AddExcludedArgument("--enable-logging");
            Option.AddExcludedArgument("--log-level=0");
            Option.AddExcludedArgument("--no-first-run");
            Option.AddExcludedArgument("--password-store=basic");
            Option.AddExcludedArgument("--no-service-autorun");

            Option.AddArgument("--disable-web-security");
            Option.AddArgument("ignore-certificate-errors");
            Option.AddArgument("--disable-fre");
            Option.AddArgument("--no-default-browser-check");
            Option.AddArgument("--no-first-run");
            Option.AddArgument("--no-pdf-header-footer");
            Option.AddArgument("--disable-encryption");
            Option.AddArgument("--donut-pie=undefined");
            Option.AddArgument("--font-masking-mode=2");
            Option.AddArgument("--restore-last-session");
            Option.AddArgument("--lang=en-US");

            Option.AddArgument("--window-size=1920,1080");
            Option.AddAdditionalOption("resolution", "1920x1080");

            Option.AddArgument("--force-device-scale-factor=0.7");//auto zoom text all cua so "only chrome" nho lai

            Option.AddArgument("--load-extension=" + Path_Extension_Solver_ReCaptcha_CaptCha69_Com);
            Option.AddArgument("--proxy-bypass-list=captcha69.com");// bỏ qua proxy khi load trang web captcha69.com - áp dụng cho cả requests bên trong extensions
            Option.AddArgument("--proxy-server=" + Proxy_IP + ":" + Proxy_Port);


            // chặn link
            ChromeDriver Driver = new ChromeDriver(service, Option, TimeSpan.FromMinutes(3.0));
            Dictionary<string, object> listURL = new Dictionary<string, object>();
            string[] durl = {
                        "https://cdn.livechatinc.com/tracking.js",
                        //"https://www.livechatinc.com/chat-with/12512850/",
                        //"https://www.livechatinc.com/?welcome"
                    };
            listURL.Add("urls", durl);
            Driver.ExecuteCdpCommand("Network.setBlockedURLs", listURL);
            Dictionary<string, object> listURL22 = new Dictionary<string, object>();
            Driver.ExecuteCdpCommand("Network.enable", listURL22);


            Driver.Navigate().GoToUrl("https://captcha69.com/");
            Driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(3.0));
```
