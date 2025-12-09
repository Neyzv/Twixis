// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Extensions;
using Twixis.Api.Internal.Http;
using Twixis.Api.Internal.Http.Uri;
using Twixis.Api.Requests.Analytics;
using Twixis.Api.Responses;
using Twixis.Api.Responses.Analytics;

namespace Twixis.Api.Endpoints;

public sealed class Analytics
{
    private readonly TwitchHttpClient _http;

    public Analytics(TwitchHttpClient http)
    {
        _http = http;
    }

    public Task<TwitchPaginatedResponse<GetExtensionAnalyticsResponse>> GetExtensionAnalyticsAsync(GetExtensionAnalyticsRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("analytics/extensions")
            .AddParameter("extension_id", request.ExtensionId)
            .AddParameter("type", request.Type)
            .AddParameter("started_at", request.StartedAt?.ToRfc3339String())
            .AddParameter("ended_at", request.EndedAt?.ToRfc3339String())
            .AddParameter("first", request.First)
            .AddParameter("after", request.After)
            .Build();

        return _http.SendRequestPaginatedAsync<GetExtensionAnalyticsResponse>(HttpMethod.Get, url, cancellationToken);
    }

    public Task<TwitchPaginatedResponse<GetGameAnalyticsResponse>> GetGameAnalyticsAsync(GetGameAnalyticsRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("analytics/games")
            .AddParameter("game_id", request.GameId)
            .AddParameter("type", request.Type)
            .AddParameter("started_at", request.StartedAt?.ToRfc3339String())
            .AddParameter("ended_at", request.EndedAt?.ToRfc3339String())
            .AddParameter("first", request.First)
            .AddParameter("after", request.After)
            .Build();

        return _http.SendRequestPaginatedAsync<GetGameAnalyticsResponse>(HttpMethod.Get, url, cancellationToken);
    }
}
