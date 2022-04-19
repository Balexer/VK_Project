using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace VKProject.Utils;

public class Waiters
{
    private readonly WebDriverWait _wait;

    public Waiters(IWebDriver driver, TimeSpan timeOut) =>
        _wait = new WebDriverWait(driver, timeOut);

    public IWebElement WaitForVisibility(By by) =>
        _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
}
