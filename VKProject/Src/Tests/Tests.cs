using FluentAssertions;
using NUnit.Framework;
using VKProject.Constants;
using VKProject.Core.Browser;
using VKProject.Core.Browser.Service;
using VKProject.Models;
using VKProject.Pages;
using VKProject.Steps;
using VKProject.Steps.ApiSteps;
using VKProject.Tests.BaseUiTest;
using VKProject.Utils;

namespace VKProject.Tests;

public class Tests : BaseTest
{
    private Post _post;
    private Comment _comment;
    private User _user;
    private User _secondUser;

    [SetUp]
    public void SetUp()
    {
        _post = TestDataGeneratorService.GetFakePost();
        _comment = TestDataGeneratorService.GetFakeComment();
        _user = DataBaseReader.GetUser(0);
        _secondUser = DataBaseReader.GetUser(1);
    }

    [Test]
    public void TC1()
    {
        LoginSteps.Login(0);
        NewsPage.MoveToMyPage();
        var postId = PostApiHelper.CreatePost(0, _post);
        MyPage.GetCreatorNameFromPost(postId).Should().Be(_user.UserId);
        MyPage.GetTextFromPost(postId).Should().Be(_post.Text);
        _post = TestDataGeneratorService.GetFakePost();
        PostApiHelper.EditPost(0, _post, postId);
        MyPage.GetTextFromPost(postId).Should().Be(_post.Text);
        MyPage.GetPhotoIdFromPost(postId).Should().Be($"https://vk.com/{AttachmentsConstants.PhotoId}");
        PostApiHelper.LeaveComment(0, postId, _comment);
        MyPage.GetCommentCreatorFromPost(postId).Should().Be(_user.UserId);
        MyPage.LikePost(postId);
        PostApiHelper.GetLikesFromPost(0, 0, postId).Should().Be(_user.UserId);
        PostApiHelper.DeletePost(0, postId);
        MyPage.IsPostVisible(postId).Should().BeFalse();
    }

    [Test]
    public void TC2()
    {
        LoginSteps.Login(0);
        NewsPage.MoveToMyPage();
        var postId = PostApiHelper.CreatePost(0, _post);
        var url = BrowsersService.Driver.Url;
        MyPage.LikePost(postId);
        MyPage.Logout();
        BrowsersService.Driver.Navigate().GoToUrl(BrowserSettings.Url);
        LoginSteps.Login(1);
        BrowsersService.Driver.Navigate().GoToUrl(url);
        MyPage.GetTextFromPost(postId).Should().Be(_post.Text);
        MyPage.LikePost(postId);
        PostApiHelper.GetLikesFromPost(0, 0, postId).Should().Be(_secondUser.UserId);
        PostApiHelper.GetLikesFromPost(0, 1, postId).Should().Be(_user.UserId);
    }
}
