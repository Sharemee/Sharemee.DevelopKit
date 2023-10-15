namespace Sharemee.DevelopKit.WindowsApi;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
internal class DescriptionUriAttribute : Attribute
{
    public string Uri { get; set; } = null!;

    public DescriptionUriAttribute(string uri)
    {
        Uri = uri;
    }
}
