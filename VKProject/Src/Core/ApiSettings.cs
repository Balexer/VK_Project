using VKProject.Utils;

namespace VKProject.Core;

public static class ApiSettings
{
    public static string BaseApiUrl => ReadProperties.Configuration[nameof(BaseApiUrl)];
    public static string ApiVersion => ReadProperties.Configuration[nameof(ApiVersion)];
}
