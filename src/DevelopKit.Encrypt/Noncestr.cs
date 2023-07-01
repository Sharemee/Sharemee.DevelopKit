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
#if NETSTANDARD2_1_OR_GREATER
            sb.Append(Symbol.AsSpan(rd.Next(0, Symbol.Length), 1));
#else
            int randomValue = rd.Next(0, Symbol.Length);
            var value = Symbol.AsSpan(randomValue, 1);
            sb.Append(value[0]);
#endif
        }
        return sb.ToString();
    }
}
