using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Sharemee.DevelopKit.Network;

public class WebApiRequest : IHttpRequest
{
    private readonly IHttpClientFactory httpClientFactory;

    public IOptions<WebApiRequestOptions> WebApiRequestOptions { get; }

    public WebApiRequest(IHttpClientFactory httpClientFactory, IOptions<WebApiRequestOptions> options)
    {
        this.httpClientFactory = httpClientFactory;
        WebApiRequestOptions = options;
    }

    #region IHttpGet

    public async Task<HttpResponseMessage> GetAsync(string key, string? parameters)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        if (parameters is not null && parameters.Length > 0 && !parameters[0].Equals('?'))
        {
            throw new ArgumentException("invaild argument", nameof(parameters));
        }

        var option = WebApiRequestOptions.Value;

        using var client = httpClientFactory.CreateClient(option.Name);
        ApiEndpoint endpoint = option.Endpoints[key];
        if (endpoint.Url is null)
        {
            throw new ArgumentException("ApiEndpoint.Url is invaild");
        }
        return await client.GetAsync(endpoint.Url + parameters).ConfigureAwait(false);
    }

    public async Task<HttpResponseMessage> GetAsync<TParame>(string key, TParame parame) where TParame : class
    {
        if (key is null) throw new ArgumentNullException(nameof(key));

        var option = WebApiRequestOptions.Value;

        using var client = httpClientFactory.CreateClient(option.Name);

        string url = WebApiRequestConverter.ToUrlParameter(option.Endpoints[key].Url, parame);

        return await client.GetAsync(url);
    }

    public async Task<TResult?> GetAsync<TResult, TParame>(string key, TParame parame)
        where TResult : class, new()
        where TParame : class
    {
        HttpResponseMessage response = await GetAsync(key, parame);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        string content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(content))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<TResult>(content);
    }

    #endregion

    #region IHttpPost

    public async Task<HttpResponseMessage> PostAsync(string key)
    {
        if (key is null) throw new ArgumentNullException(nameof(key));
        var option = WebApiRequestOptions.Value;

        using var client = httpClientFactory.CreateClient(option.Name);
        ApiEndpoint endpoint = option.Endpoints[key];
        if (endpoint.Url is not null)
        {
            throw new ArgumentException("ApiEndpoint.Url is invaild");
        }
        return await client.PostAsync(endpoint.Url, null).ConfigureAwait(false);
    }

    public async Task<HttpResponseMessage> PostAync<TParame>(string key, TParame parame) where TParame : class
    {
        var option = WebApiRequestOptions.Value;
        ApiEndpoint endpoint = option.Endpoints[key];

        using var client = httpClientFactory.CreateClient(option.Name);
        if (endpoint.Url is null)
        {
            throw new ArgumentException("ApiEndpoint.Url is invaild");
        }
        string json = JsonConvert.SerializeObject(parame);
        HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
        return await client.PostAsync(endpoint.Url, content).ConfigureAwait(false);
    }

    public async Task<TResult?> PostAync<TResult, TParame>(string key, TParame parame)
        where TResult : class, new()
        where TParame : class
    {
        HttpResponseMessage response = await PostAync(key, parame);

        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        string content = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrEmpty(content))
        {
            return default;
        }

        return JsonConvert.DeserializeObject<TResult>(content);
    }

    #endregion

    public async Task<HttpResponseMessage> SendAsync(string key)
    {
        var option = WebApiRequestOptions.Value;
        var endpoint = WebApiRequestOptions.Value.Endpoints[key];

        using var client = httpClientFactory.CreateClient(option.Name);

        HttpRequestMessage request = new(new HttpMethod(endpoint.Method.ToString()), endpoint.Url);

        return await client.SendAsync(request);
    }

    public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage HttpResponseMessage)
    {
        var option = WebApiRequestOptions.Value;
        using var client = httpClientFactory.CreateClient(option.Name);
        return await client.SendAsync(HttpResponseMessage);
    }

    public async Task<HttpResponseMessage> SendAsync<TParame>(string key, TParame parame) where TParame : class
    {
        var option = WebApiRequestOptions.Value;
        var endpoint = WebApiRequestOptions.Value.Endpoints[key];

        using var client = httpClientFactory.CreateClient(option.Name);

        return endpoint.Method switch
        {
            MethodType.Post => await PostAync(key, parame),
            _ => await GetAsync(key, parame),
        };
    }

    public async Task<TResult?> SendAsync<TResult>(HttpRequestMessage httpRequestMessage) where TResult : class
    {
        var option = WebApiRequestOptions.Value;

        using var client = httpClientFactory.CreateClient(option.Name);
        var responseMessage = await client.SendAsync(httpRequestMessage);
        if (!responseMessage.IsSuccessStatusCode)
        {
            return default;
        }
        string content = await responseMessage.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(content))
        {
            return default;
        }
        TResult? result = JsonConvert.DeserializeObject<TResult?>(content);
        return result;
    }

    public async Task<TResult?> SendAsync<TResult, TParame>(string key, TParame parame)
       where TParame : class
        where TResult : class
    {
        HttpResponseMessage response = await SendAsync(key, parame);
        if (!response.IsSuccessStatusCode)
        {
            return default;
        }

        string content = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(content))
        {
            return default;
        }

        TResult? result = JsonConvert.DeserializeObject<TResult?>(content);

        return result;
    }
}
