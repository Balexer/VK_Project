using Newtonsoft.Json.Linq;
using RestSharp;
using VKProject.Constants;
using VKProject.Models;
using VKProject.Steps.ApiSteps.Base;

namespace VKProject.Steps.ApiSteps;

public class PostApiHelper : BaseApiHelper
{
    public static string CreatePost(int userId, Post post)
    {
        var parameters = $"{BaseParameter(userId)}&{ParameterNames.Message}{post.Text}";
        dynamic r = JObject.Parse(Client($"{URIConstants.BaseApiUrl}{WallMethods.Post}{parameters}")
            .Execute(BaseRequest(Method.POST)).Content);
        return r.response.post_id;
    }

    public static void EditPost(int userId, Post post, string postId)
    {
        var parameters =
            $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}" +
            $"&{ParameterNames.Attachments}{AttachmentsConstants.PhotoId}" +
            $"&{ParameterNames.Message}{post.Text}";
        Client($"{URIConstants.BaseApiUrl}{WallMethods.Edit}{parameters}")
            .Execute(BaseRequest(Method.POST));
    }

    public static void LeaveComment(int userId, string postId, Comment comment)
    {
        var parameters =
            $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}" +
            $"&{ParameterNames.Message}{comment.Text}";
        Client($"{URIConstants.BaseApiUrl}{WallMethods.CreateComment}{parameters}")
            .Execute(BaseRequest(Method.POST));
    }

    public static string GetLikesFromPost(int userId, string postId)
    {
        var parameters = $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}";
        dynamic r = JObject.Parse(Client($"{URIConstants.BaseApiUrl}{WallMethods.GetLikes}{parameters}")
            .Execute(BaseRequest(Method.POST)).Content);
        return r.response.users[0].uid;
    }

    public static void DeletePost(int userId, string postId)
    {
        var parameters = $"{BaseParameter(userId)}&{ParameterNames.PostId}{postId}";
        Client($"{URIConstants.BaseApiUrl}{WallMethods.Delete}{parameters}")
            .Execute(BaseRequest(Method.POST));
    }
}
