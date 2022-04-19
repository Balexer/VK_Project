using FluentAssertions;
using NUnit.Framework;
using VKProject.Constants;
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

    [SetUp]
    public void SetUp()
    {
        _post = TestDataGeneratorService.GetFakePost();
        _comment = TestDataGeneratorService.GetFakeComment();
        _user = DataBaseReader.GetUser(1);
    }

    [Test]
    public void TC1()
    {
        LoginSteps.Login(1);
        NewsPage.MoveToMyPage();
        var postId = PostApiHelper.CreatePost(1, _post);
        MyPage.GetCreatorNameFromPost(postId).Should().Be(_user.UserId);
        MyPage.GetTextFromPost(postId).Should().Be(_post.Text);
        _post = TestDataGeneratorService.GetFakePost();
        PostApiHelper.EditPost(1, _post, postId);
        MyPage.GetTextFromPost(postId).Should().Be(_post.Text);
        MyPage.GetPhotoIdFromPost(postId).Should().Be($"https://vk.com/{AttachmentsConstants.PhotoId}");
        PostApiHelper.LeaveComment(1, postId, _comment);
        MyPage.GetCommentCreatorFromPost(postId).Should().Be(_user.UserId);
        MyPage.LikePost(postId);
        PostApiHelper.GetLikesFromPost(1, postId).Should().Be(_user.UserId);
        PostApiHelper.DeletePost(1, postId);
        MyPage.IsPostVisible(postId).Should().BeFalse();
    }
}
