using OpenQA.Selenium;
using VKProject.Core.Browser.Service;
using VKProject.Wrappers;

namespace VKProject.Pages.Base;

public abstract class BasePage
{
    private static readonly By MyPageSelector = By.XPath("//li[@id='l_pr']//a");
    private static readonly By LogoutButtonSelector = By.Id("top_logout_link");
    private static readonly By ProfileArrowSelector = By.ClassName("TopNavBtn__profileArrow");

    public static void MoveToMyPage() =>
        new Button(MyPageSelector).Click();

    public static void Logout()
    {
        new Button(ProfileArrowSelector).Click();
        new Button(LogoutButtonSelector).Click();
    }
}
