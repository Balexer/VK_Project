using System;
using VKProject.Utils;

namespace VKProject.Core.Browser;

public class BrowserSettings
{
    public static string Url => ReadProperties.Configuration[nameof(Url)];
    public static string Browser => ReadProperties.Configuration[nameof(Browser)];
    public static TimeSpan Timeout => TimeSpan.FromSeconds(double.Parse(ReadProperties.Configuration[nameof(Timeout)]));
}
