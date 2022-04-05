using OpenQA.Selenium;
using VKProject.Pages.Base;

namespace VKProject.Pages;

public class LoginPage : BasePage
{
    private static readonly By InButtonSelector = By.ClassName("FlatButton__in");
    private static readonly By LoginSelector = By.Name("login");
    private static readonly By PasswordSelector = By.Name("password");
    private static readonly By ContinueButtonSelector = By.ClassName("vkc__Button__title");

    private static void ClickContinueButton() =>
        GetElement(ContinueButtonSelector).Click();

    public static void ClickInButton() =>
        GetElement(InButtonSelector).Click();

    public static void SetLogin(string? login)
    {
        GetElement(LoginSelector).SendKeys(login);
        ClickContinueButton();
    }

    public static void SetPassword(string? password)
    {
        GetElement(PasswordSelector).SendKeys(password);
        ClickContinueButton();
    }
}
