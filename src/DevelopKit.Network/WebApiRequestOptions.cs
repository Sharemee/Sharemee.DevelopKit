namespace Sharemee.DevelopKit.Network;

public class WebApiRequestOptions
{
    /// <summary>
    /// 配置节点名称
    /// </summary>
    public string Name { get; set; } = null!;

    public string AppId { get; set; } = string.Empty;
    public string AppSecret { get; set; } = string.Empty;

    /// <summary>
    /// 域名
    /// </summary>
    public string Domain { get; set; } = null!;

    /// <summary>
    /// 超时时间
    /// </summary>
    /// <remarks>默认30秒</remarks>
    public int? Timeout { get; set; }

    /// <summary>
    /// 接口列表
    /// </summary>
    public Dictionary<string, ApiEndpoint> Endpoints { get; set; } = new Dictionary<string, ApiEndpoint>();

    /// <summary>
    /// 静态请求头
    /// </summary>
    public Dictionary<string, string> RequestHeaders { get; set; } = new Dictionary<string, string>();

    public WebApiRequestOptions CopyFrom(WebApiRequestOptions options)
    {
        this.Name = options.Name;
        this.AppId = options.AppId;
        this.AppSecret = options.AppSecret;
        this.Domain = options.Domain;
        this.Timeout = options.Timeout;
        this.Endpoints = options.Endpoints;
        this.RequestHeaders = options.RequestHeaders;
        return this;
    }

    public WebApiRequestOptions CopyTo(WebApiRequestOptions options)
    {
        options.Name = this.Name;
        options.AppId = this.AppId;
        options.AppSecret = this.AppSecret;
        options.Domain = this.Domain;
        options.Timeout = this.Timeout;
        options.Endpoints = this.Endpoints;
        options.RequestHeaders = this.RequestHeaders;
        return this;
    }
}

public class ApiEndpoint
{
    public MethodType Method { get; set; }

    public string Url { get; set; } = string.Empty;        
}

public enum MethodType
{
    Get,
    Post,
}
