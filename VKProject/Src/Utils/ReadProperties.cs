using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using VKProject.Constants;

namespace VKProject.Utils;

public class ReadProperties
{
    private static readonly Lazy<IConfiguration> Configurations = new(BuildConfiguration);
    private static readonly string Filepath =
        $@"src{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}{ResourcesConstants.AppSettings}.{ExtensionsConstants.Json}";

    public static IConfiguration Configuration => Configurations.Value;

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile(Filepath);

        var appSettingFiles = Directory.EnumerateFiles(basePath,
            $"{ResourcesConstants.AppSettings}.*.{ExtensionsConstants.Json}");

        foreach (var appSettingFile in appSettingFiles)
        {
            builder.AddJsonFile(appSettingFile);
        }

        return builder.Build();
    }
}
