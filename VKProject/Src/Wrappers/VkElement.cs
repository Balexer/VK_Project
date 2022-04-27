using OpenQA.Selenium;

namespace VKProject.Wrappers;

public class VkElement : BaseElement
{
    public VkElement(By locator) : base(locator)
    {
    }

    public string GetAttribute(string attributeName) =>
        Element.GetAttribute(attributeName);

    public string GetText() =>
        Element.Text;
}
