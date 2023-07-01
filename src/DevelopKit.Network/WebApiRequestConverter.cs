using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Sharemee.DevelopKit.Network;

internal class WebApiRequestConverter
{
    internal static string ToUrlParameter<Tparam>(string url, Tparam parame) where Tparam : class
    {
        if (parame is null) return url;

        Type type = parame.GetType();
        PropertyInfo[] properties = type.GetProperties();
        if (properties.Length == 0) return url;

        StringBuilder stringBuilder = new(url);
        stringBuilder.Append('?');
        foreach (PropertyInfo property in properties)
        {
            string name = property.Name;
            var attributes = property.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
            foreach (var attribute in attributes)
            {
                if (attribute is JsonPropertyAttribute jsonProperty)
                {
                    string tmpName = jsonProperty.PropertyName ?? string.Empty;
                    if (string.IsNullOrEmpty(tmpName))
                    {
                        continue;
                    }
                    name = tmpName;
                    break;
                }
            }
            stringBuilder.Append($"{name}={property.GetValue(parame)}&");
        }
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
        return stringBuilder.ToString();
    }

    internal static HttpMethod ToHttpMethod(MethodType methodType) => new(methodType.ToString());

    internal static HttpMethod FromMethodType(MethodType methodType)
    {
        return methodType switch
        {
            MethodType.Post => HttpMethod.Post,
            _ => HttpMethod.Get,
        };
    }
}
