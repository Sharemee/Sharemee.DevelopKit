using System.Security.Cryptography;
using System.Text;

namespace Sharemee.DevelopKit.Encrypt;

public class Md5
{
    public static string ComputeHash(string content, bool lowercase = false)
    {
        return ComputeHash(content, Encoding.UTF8, lowercase);
    }

    public static string ComputeHash(string content, Encoding encoding, bool lowercase = false)
    {
        var bytes = encoding.GetBytes(content);
        return ComputeHash(bytes, lowercase);
    }

    public static string ComputeHash(byte[] content, bool lowercase = false)
    {
        using MD5 md5 = MD5.Create();
        byte[] hash = md5.ComputeHash(content);
        var sb = new StringBuilder(32);
        string fmt = lowercase ? "{0:x2}" : "{0:X2}";
        foreach (byte b in hash)
        {
            sb.AppendFormat(fmt, b);
        }
        return sb.ToString();
    }
}
