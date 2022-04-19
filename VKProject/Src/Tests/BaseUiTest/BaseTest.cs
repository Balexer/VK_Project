using NUnit.Framework;
using VKProject.Core.Browser;
using VKProject.Core.Browser.Service;

namespace VKProject.Tests.BaseUiTest;

public abstract class BaseTest
{
    [SetUp]
    public void OpenPage()
    {
        BrowsersService.SetupBrowser();
        BrowsersService.Driver.Navigate().GoToUrl(BrowserSettings.Url);
    }

    [TearDown]
    public void ClosePage()
    {
        BrowsersService.Driver.Quit();
        BrowsersService.Driver = null;
    }
}
