// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Twixis.Api.Internal.Json;
using Twixis.Api.Requests;
using Twixis.Api.Responses;

namespace Twixis.Api.Internal.Http;

public sealed class TwitchHttpClient
{
    private readonly HttpClient _http;
    private readonly TwitchHttpClientOptions _options;

    public TwitchHttpClient(HttpClient http, IOptions<TwitchHttpClientOptions> options)
    {
        _http = http;
        _options = options.Value;
    }

    public Task SendRequestAsync(HttpMethod httpMethod, [StringSyntax(StringSyntaxAttribute.Uri)] string url, CancellationToken cancellationToken)
    {
        return SendAsync(new HttpRequestMessage(httpMethod, url), cancellationToken);
    }

    public Task SendRequestAsync<TRequest>(HttpMethod httpMethod, [StringSyntax(StringSyntaxAttribute.Uri)] string url, TRequest request, CancellationToken cancellationToken)
        where TRequest : TwitchRequest
    {
        var httpRequest = new HttpRequestMessage(httpMethod, url);

        httpRequest.Content = JsonContent.Create(request, TwitchJsonSerializerContext.Default.GetTypeInfo<TRequest>());

        return SendAsync(httpRequest, cancellationToken);
    }

    public Task<TwitchResponse<TResponse>> SendRequestAsync<TResponse>(
        HttpMethod httpMethod,
        [StringSyntax(StringSyntaxAttribute.Uri)] string url,
        CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(httpMethod, url);

        return SendAsync<TwitchResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    public Task<TwitchResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(
        HttpMethod httpMethod,
        [StringSyntax(StringSyntaxAttribute.Uri)] string url,
        TRequest request,
        CancellationToken cancellationToken)
        where TRequest : TwitchRequest
        where TResponse : class
    {
        var httpRequest = new HttpRequestMessage(httpMethod, url);

        httpRequest.Content = JsonContent.Create(request, TwitchJsonSerializerContext.Default.GetTypeInfo<TRequest>());

        return SendAsync<TwitchResponse<TResponse>, TResponse>(httpRequest, cancellationToken);
    }

    public Task<TwitchPaginatedResponse<TResponse>> SendRequestPaginatedAsync<TResponse>(
        HttpMethod httpMethod,
        [StringSyntax(StringSyntaxAttribute.Uri)] string url,
        CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(httpMethod, url);

        return SendAsync<TwitchPaginatedResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    public Task<TwitchPaginatedWithTotalResponse<TResponse>> SendRequestPaginatedWithTotalAsync<TResponse>(
        HttpMethod httpMethod,
        [StringSyntax(StringSyntaxAttribute.Uri)] string url,
        CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(httpMethod, url);

        return SendAsync<TwitchPaginatedWithTotalResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    public Task<TwitchDatedResponse<TResponse>> SendRequestDatedAsync<TResponse>(
        HttpMethod httpMethod,
        [StringSyntax(StringSyntaxAttribute.Uri)] string url,
        CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(httpMethod, url);

        return SendAsync<TwitchDatedResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    private void SetupRequest(HttpRequestMessage request)
    {
        request.Headers.TryAddWithoutValidation("Client-ID", _options.ClientId);
        request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_options.AccessToken}");
    }

    private async Task SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        using (request)
        {
            SetupRequest(request);
            using var _ = await _http.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }

    private async Task<TTwitchResponse> SendAsync<TTwitchResponse, TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
        where TTwitchResponse : TwitchResponse<TResponse>
        where TResponse : class
    {
        using (request)
        {
            SetupRequest(request);

            using var response = await _http.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var typedResponse = await response.Content.ReadFromJsonAsync(TwitchJsonSerializerContext.Default.GetTypeInfo<TTwitchResponse>(), cancellationToken).ConfigureAwait(false);

            return typedResponse ?? throw new InvalidOperationException("The response from Twitch API was null or could not be deserialized.");
        }
    }
}
