using System.Text;

namespace Sharemee.DevelopKit.Encrypt;

public class Noncestr
{
    private const string Symbol = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public static string Create(int length = 6)
    {
        var sb = new StringBuilder(length + 1);
        var rd = new Random();
        for (int i = 0; i < length; i++)
        {
            int randomValue = rd.Next(0, Symbol.Length);
#if NETSTANDARD2_0
            var value = Symbol.Substring(randomValue, 1);
#else
            var value = Symbol.AsSpan(randomValue, 1);
#endif
            sb.Append(value[0]);
        }
        return sb.ToString();
    }
}
