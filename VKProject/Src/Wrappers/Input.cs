using OpenQA.Selenium;

namespace VKProject.Wrappers;

public class Input : BaseElement
{
    public Input(By locator) : base(locator)
    {
    }

    public void SendKeys(string value) =>
        Element.SendKeys(value);
}
