using OpenQA.Selenium;
using VKProject.Core.Browser.Service;
using VKProject.Pages.Base;

namespace VKProject.Pages;

public class MyPage : BasePage
{
    private const string PostLocator = "//div[contains(@id,'replace')]";
    private const string PostAuthorLocator = "//a[contains(@data-post-id,'replace')]";
    private const string PostTextLocator = $"{PostLocator}/div[contains(@class,'wall_post_text')]";
    private const string PostPhotoLocator = $"{PostLocator}//a[@aria-label='фотография']";
    private const string PostCommentLocator = $"{PostLocator}//div[@class='replies']//div[contains(@class,'reply')]";
    private const string PostLikeButtonLocator = $"{PostLocator}//div[@data-section-ref='reactions-button-container']";

    public static string GetCreatorNameFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return GetElement(ReplaceLocator(PostAuthorLocator, postId)).GetAttribute("data-from-id");
    }

    public static string GetTextFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return GetElement(ReplaceLocator(PostTextLocator, postId)).Text;
    }

    public static string GetCommentCreatorFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return GetElement(ReplaceLocator(PostCommentLocator, postId)).GetAttribute("data-answering-id");
    }

    public static void LikePost(string postId) =>
        GetElement(ReplaceLocator(PostLikeButtonLocator, postId)).Click();

    public static string GetPhotoIdFromPost(string postId) =>
        $"photo{GetElement(ReplaceLocator(PostPhotoLocator, postId)).GetAttribute("data-photo-id")}";

    public static bool IsPostVisible(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        try
        {
            return GetElement(ReplaceLocator(PostLocator, postId)).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
