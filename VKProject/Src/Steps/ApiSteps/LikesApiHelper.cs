using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using VKProject.Constants;
using VKProject.Models.Responses.Likes;
using VKProject.Steps.ApiSteps.Base;

namespace VKProject.Steps.ApiSteps;

public class LikesApiHelper : BaseApiHelper
{
    public static List<int> GetLikes(int userId, string postId)
    {
        var parameters = $"{BaseParameter(userId)}" +
                         $"&{ParameterNames.Type}post" +
                         $"&{ParameterNames.ItemId}{postId}";
        var likesResponse = JsonConvert.DeserializeObject<LikesResponse>(Client(LikeMethods.GetLikes, parameters)
            .Execute(BaseRequest(Method.POST)).Content);
        return likesResponse.Response.Items;
    }
}
