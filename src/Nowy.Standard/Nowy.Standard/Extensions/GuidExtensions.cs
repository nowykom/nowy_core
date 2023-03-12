using System;

namespace Nowy.Standard;

public static class GuidExtensions
{
    public static string ToStringUpper(this Guid guid)
    {
        return guid.ToString("D").ToUpper();
    }
}
