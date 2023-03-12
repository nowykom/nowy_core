using System.Net;
using System.Text;

namespace Nowy.Standard;

public static class StringBuilderExtensions
{
    public static void AppendUrlEncoded(this StringBuilder sb, string name, string value)
    {
        if (sb.Length != 0)
            sb.Append("&");
        sb.Append(WebUtility.UrlEncode(name));
        sb.Append("=");
        sb.Append(WebUtility.UrlEncode(value));
    }
}
