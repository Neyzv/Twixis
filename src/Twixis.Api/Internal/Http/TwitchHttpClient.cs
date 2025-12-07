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

    public Task<TwitchPaginatedResponse<TResponse>> GetPaginatedAsync<TResponse>([StringSyntax(StringSyntaxAttribute.Uri)] string url, CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        return SendAsync<TwitchPaginatedResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    public Task<TwitchDatedResponse<TResponse>> GetDatedAsync<TResponse>([StringSyntax(StringSyntaxAttribute.Uri)] string url, CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        return SendAsync<TwitchDatedResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    public Task<TwitchResponse<TResponse>> GetAsync<TResponse>([StringSyntax(StringSyntaxAttribute.Uri)] string url, CancellationToken cancellationToken)
        where TResponse : class
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        return SendAsync<TwitchResponse<TResponse>, TResponse>(request, cancellationToken);
    }

    public Task<TwitchResponse<TResponse>> PostAsync<TResponse>([StringSyntax(StringSyntaxAttribute.Uri)] string url, CancellationToken cancellationToken)
        where TResponse : class
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, url);

        return SendAsync<TwitchResponse<TResponse>, TResponse>(httpRequest, cancellationToken);
    }

    public Task<TwitchResponse<TResponse>> PostAsync<TRequest, TResponse>([StringSyntax(StringSyntaxAttribute.Uri)] string url, TRequest request, CancellationToken cancellationToken)
        where TRequest : TwitchRequest
        where TResponse : class
    {
        var httpRequest = new HttpRequestMessage(HttpMethod.Post, url);

        httpRequest.Content = JsonContent.Create(request, TwitchJsonSerializerContext.Default.GetTypeInfo<TRequest>());

        return SendAsync<TwitchResponse<TResponse>, TResponse>(httpRequest, cancellationToken);
    }

    private async Task<TTwitchResponse> SendAsync<TTwitchResponse, TResponse>(HttpRequestMessage request, CancellationToken cancellationToken)
        where TTwitchResponse : TwitchResponse<TResponse>
        where TResponse : class
    {
        using (request)
        {
            request.Headers.TryAddWithoutValidation("Client-ID", _options.ClientId);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {_options.AccessToken}");

            using var response = await _http.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var typedResponse = await response.Content.ReadFromJsonAsync(TwitchJsonSerializerContext.Default.GetTypeInfo<TTwitchResponse>(), cancellationToken).ConfigureAwait(false);

            return typedResponse ?? throw new InvalidOperationException("The response from Twitch API was null or could not be deserialized.");
        }
    }
}
