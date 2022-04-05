using RestSharp;
using VKProject.Constants;
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
        var baseParameter = $"{ParameterNames.OwnerId}{DataBaseReader.GetUser(userId).userId}" +
                            $"&{ParameterNames.Version}{URIConstants.ApiVersion}" +
                            $"&{ParameterNames.Token}{DataBaseReader.GetUser(userId).token}";
        return baseParameter;
    }

    protected static RestClient Client(string baseUrl) =>
        new(baseUrl);
}
