using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using VKProject.Utils;

namespace VKProject.Core.Browser.Service;

public static class BrowsersService
{
    private const string Chrome = "chrome";

    public static IWebDriver Driver { get; set; }

    public static Waiters Waiters => new(Driver, BrowserSettings.Timeout);

    public static void SetupBrowser()
    {
        switch (BrowserSettings.Browser.ToLower())
        {
            case Chrome:
                Driver ??= new ChromeDriver(GetChromeOptions());
                break;
            default:
                Console.WriteLine("This browser is not supported");
                break;
        }
    }

    private static ChromeOptions GetChromeOptions()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArguments("--disable-gpu", "--ignore-certificate-errors", "--silent",
            "--start-maximized");
        return chromeOptions;
    }
}
