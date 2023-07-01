namespace Sharemee.DevelopKit.Network;

public interface IHttpGet
{
    Task<HttpResponseMessage> GetAsync(string key, string? parameters);
    Task<HttpResponseMessage> GetAsync<TParame>(string key, TParame parame) where TParame : class;
    Task<TResult?> GetAsync<TResult, TParame>(string key, TParame parame) where TResult : class, new() where TParame : class;
}

public interface IHttpPost
{
    Task<HttpResponseMessage> PostAsync(string key);
    Task<HttpResponseMessage> PostAync<TParame>(string key, TParame parame) where TParame : class;
    Task<TResult?> PostAync<TResult, TParame>(string key, TParame parame) where TResult : class, new() where TParame : class;
}

public interface IHttpSend
{
    Task<HttpResponseMessage> SendAsync(string key);

    Task<HttpResponseMessage> SendAsync(HttpRequestMessage HttpResponseMessage);

    Task<HttpResponseMessage> SendAsync<TParame>(string key, TParame parame) where TParame : class;

    Task<TResult?> SendAsync<TResult>(HttpRequestMessage httpRequestMessage) where TResult : class;

    Task<TResult?> SendAsync<TResult, TParame>(string key, TParame parame) where TParame : class where TResult : class;
}

public interface IHttpRequest : IHttpGet, IHttpPost, IHttpSend { }
