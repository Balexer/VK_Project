using VKProject.Pages;
using VKProject.Utils;

namespace VKProject.Steps;

public class LoginSteps
{
    public static void Login(int userId)
    {
        LoginPage.ClickInButton();
        LoginPage.SetLogin(DataBaseReader.GetUser(userId).login);
        LoginPage.SetPassword(DataBaseReader.GetUser(userId).password);
    }
}
