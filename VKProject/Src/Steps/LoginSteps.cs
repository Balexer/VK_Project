using VKProject.Pages;
using VKProject.Utils;

namespace VKProject.Steps;

public class LoginSteps
{
    public static void Login(int userId)
    {
        LoginPage.ClickInButton();
        LoginPage.SetLogin(DataBaseReader.GetUser(userId).Login);
        LoginPage.SetPassword(DataBaseReader.GetUser(userId).Password);
    }
}
