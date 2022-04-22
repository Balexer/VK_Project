using Newtonsoft.Json;
using RestSharp;
using VKProject.Constants;
using VKProject.Models;
using VKProject.Models.Responses.Like;
using VKProject.Models.Responses.Post;
using VKProject.Steps.ApiSteps.Base;

namespace VKProject.Steps.ApiSteps;

public class PostApiHelper : BaseApiHelper
{
    public static string CreatePost(int userId, Post post)
    {
        var parameters = $"{BaseParameter(userId)}&{ParameterNames.Message}{post.Text}";
        var postResponse = JsonConvert.DeserializeObject<PostResponse>(Client($"{WallMethods.Post}", parameters)
            .Execute(BaseRequest(Method.POST)).Content);
        return postResponse.Response.Post_id.ToString();
    }

    public static void EditPost(int userId, Post post, string postId)
    {
        var parameters =
            $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}" +
            $"&{ParameterNames.Attachments}{AttachmentsConstants.PhotoId}" +
            $"&{ParameterNames.Message}{post.Text}";
        Client($"{WallMethods.Edit}", parameters)
            .Execute(BaseRequest(Method.POST));
    }

    public static void LeaveComment(int userId, string postId, Comment comment)
    {
        var parameters =
            $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}" +
            $"&{ParameterNames.Message}{comment.Text}";
        Client($"{WallMethods.CreateComment}", parameters)
            .Execute(BaseRequest(Method.POST));
    }

    public static string GetLikesFromPost(int ownerId, int userId, string postId)
    {
        var parameters = $"{BaseParameter(ownerId)}&{ParameterNames.PostId}{postId}";
        var likesResponse = JsonConvert.DeserializeObject<LikesResponse>(Client($"{WallMethods.GetLikes}", parameters)
            .Execute(BaseRequest(Method.POST)).Content);
        return likesResponse.Response.Users[userId].Uid.ToString();
    }

    public static void DeletePost(int userId, string postId)
    {
        var parameters = $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}";
        Client($"{WallMethods.Delete}", parameters)
            .Execute(BaseRequest(Method.POST));
    }
}
