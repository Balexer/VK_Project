using OpenQA.Selenium;
using VKProject.Pages.Base;
using VKProject.Wrappers;

namespace VKProject.Pages;

public class NewsPage : BasePage
{
    private static readonly By MyPageSelector = By.XPath("//li[@id='l_pr']//a");

    public static void MoveToMyPage() =>
        new Button(MyPageSelector).Click();
}
