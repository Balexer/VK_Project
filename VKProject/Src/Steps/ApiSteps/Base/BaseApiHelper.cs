using RestSharp;
using VKProject.Constants;
using VKProject.Core;
using VKProject.Utils;

namespace VKProject.Steps.ApiSteps.Base;

public class BaseApiHelper
{
    protected static IRestRequest BaseRequest(Method method)
    {
        var request = new RestRequest(method);
        return request;
    }

    protected static string BaseParameter(int userId)
    {
        var baseParameter = $"{ParameterNames.OwnerId}{DataBaseReader.GetUser(userId).UserId}" +
                            $"&{ParameterNames.Version}{ApiSettings.ApiVersion}" +
                            $"&{ParameterNames.Token}{DataBaseReader.GetUser(userId).Token}";
        return baseParameter;
    }

    protected static RestClient Client(string method, string parameters) =>
        new($"{ApiSettings.BaseApiUrl}method/{method}?{parameters}");
}
