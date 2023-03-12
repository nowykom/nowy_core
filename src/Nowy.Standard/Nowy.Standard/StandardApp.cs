using System;

namespace Nowy.Standard;

public static class StandardApp
{
    public static IServiceProvider Services { get; set; } = null!;

    public static string AppVersion { get; set; } = "0";
    public static string AppName { get; set; } = "unknown-app";
    public static string AppTitle { get; set; } = "Unknown App";
}
