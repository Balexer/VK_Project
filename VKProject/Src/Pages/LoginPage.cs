using OpenQA.Selenium;
using VKProject.Pages.Base;
using VKProject.Wrappers;

namespace VKProject.Pages;

public class LoginPage : BasePage
{
    private static readonly By InButtonSelector = By.ClassName("FlatButton__in");
    private static readonly By LoginSelector = By.Name("login");
    private static readonly By PasswordSelector = By.Name("password");
    private static readonly By ContinueButtonSelector = By.ClassName("vkc__Button__title");

    private static void ClickContinueButton() =>
        new Button(ContinueButtonSelector).Click();

    public static void ClickInButton() =>
        new Button(InButtonSelector).Click();

    public static void SetLogin(string? login)
    {
        new Input(LoginSelector).SendKeys(login);
        ClickContinueButton();
    }

    public static void SetPassword(string? password)
    {
        new Input(PasswordSelector).SendKeys(password);
        ClickContinueButton();
    }
}
