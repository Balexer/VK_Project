using OpenQA.Selenium;
using VKProject.Core.Browser.Service;
using VKProject.Pages.Base;
using VKProject.Wrappers;

namespace VKProject.Pages;

public class MyPage : BasePage
{
    private static readonly By ProfileArrowSelector = By.ClassName("TopNavBtn__profileArrow");
    private static readonly By LogoutButtonSelector = By.Id("top_logout_link");
    private const string PostLocator = "//div[contains(@id,'replace')]";
    private const string PostAuthorLocator = "//a[contains(@data-post-id,'replace')]";
    private const string PostTextLocator = $"{PostLocator}/div[contains(@class,'wall_post_text')]";
    private const string PostPhotoLocator = $"{PostLocator}//a[@aria-label='фотография']";
    private const string PostCommentLocator = $"{PostLocator}//div[@class='replies']//div[contains(@class,'reply')]";
    private const string PostLikeButtonLocator = $"{PostLocator}//div[@data-section-ref='reactions-button-container']";

    public static void Logout()
    {
        new Button(ProfileArrowSelector).Click();
        new Button(LogoutButtonSelector).Click();
    }

    public static string GetCreatorNameFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return new VkElement(ReplaceLocator(PostAuthorLocator, postId)).GetAttribute("data-from-id");
    }

    public static string GetTextFromPost(string postId)
    {
        try
        {
            BrowsersService.Driver.SwitchTo().Alert().Accept();
        }
        catch (NoAlertPresentException)
        {
        }

        BrowsersService.Driver.Navigate().Refresh();
        return new VkElement(ReplaceLocator(PostTextLocator, postId)).GetText();
    }

    public static string GetCommentCreatorFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return new VkElement(ReplaceLocator(PostCommentLocator, postId)).GetAttribute("data-answering-id");
    }

    public static void LikePost(string postId) =>
        new Button(ReplaceLocator(PostLikeButtonLocator, postId)).Click();

    public static string GetPhotoIdFromPost(string postId) =>
        new VkElement(ReplaceLocator(PostPhotoLocator, postId)).GetAttribute("href");

    public static bool IsPostVisible(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        try
        {
            return new VkElement(ReplaceLocator(PostLocator, postId)).IsDisplayed();
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
