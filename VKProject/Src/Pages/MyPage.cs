using OpenQA.Selenium;
using VKProject.Core.Browser.Service;
using VKProject.Pages.Base;
using VKProject.Wrappers;

namespace VKProject.Pages;

public class MyPage : BasePage
{
    private const string PostLocator = "//div[contains(@id,'{0}')]";
    private const string PostAuthorLocator = "//a[contains(@data-post-id,'{0}')]";
    private const string PostTextLocator = $"{PostLocator}/*[contains(@class,'wall_post_text')]";
    private const string PostPhotoLocator = $"{PostLocator}//*[@aria-label='photo']";
    private const string PostCommentLocator = $"{PostLocator}//*[@class='replies']//div[contains(@class,'reply')]";
    private const string PostLikeButtonLocator = $"{PostLocator}//*[@data-section-ref='reactions-button-container']";
    private const string PostDocLocator = $"{PostLocator}/*[@class='page_doc_title']";

    public static string GetCreatorNameFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return new VkElement(By.XPath(string.Format(PostAuthorLocator, postId))).GetAttribute("data-from-id");
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
        return new VkElement(By.XPath(string.Format(PostTextLocator, postId))).GetText();
    }

    public static string GetCommentCreatorFromPost(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return new VkElement(By.XPath(string.Format(PostCommentLocator, postId))).GetAttribute("data-answering-id");
    }

    public static void LikePost(string postId) =>
        new Button(By.XPath(string.Format(PostLikeButtonLocator, postId))).Click();

    public static string GetPhotoIdFromPost(string postId) =>
        new VkElement(By.XPath(string.Format(PostPhotoLocator, postId))).GetAttribute("href");

    public static string GetDocTitleFromPost(string postId) =>
        new VkElement(By.XPath(string.Format(PostDocLocator, postId))).GetText();

    public static bool IsPostVisible(string postId)
    {
        BrowsersService.Driver.Navigate().Refresh();
        return new VkElement(By.XPath(string.Format(PostLocator, postId))).IsDisplayed();
    }
}
