using OpenQA.Selenium;
using VKProject.Core.Browser.Service;

namespace VKProject.Pages.Base;

public abstract class BasePage
{
    protected static By ReplaceLocator(string locator, string elementName) =>
        By.XPath(locator.Replace("replace", elementName));
}
