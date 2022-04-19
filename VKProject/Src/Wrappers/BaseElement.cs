using OpenQA.Selenium;
using VKProject.Core.Browser.Service;

namespace VKProject.Wrappers;

public abstract class BaseElement
{
    private readonly By _by;

    protected BaseElement(By by) =>
        _by = by;

    private static IWebElement GetElement(By locator) =>
        BrowsersService.Waiters.WaitForVisibility(locator);

    protected IWebElement Element => GetElement(_by);
}
