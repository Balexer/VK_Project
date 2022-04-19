using AngleSharp.Dom;
using OpenQA.Selenium;

namespace VKProject.Wrappers;

public class Button : BaseElement
{
    public Button(By locator) : base(locator)
    {
    }

    public void Click() =>
        Element.Click();
}
