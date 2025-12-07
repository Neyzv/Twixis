// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Extensions;
using Twixis.Api.Internal.Http;
using Twixis.Api.Internal.Http.Uri;
using Twixis.Api.Requests.Bits;
using Twixis.Api.Responses;
using Twixis.Api.Responses.Bits;

namespace Twixis.Api.Endpoints;

public sealed class Bits
{
    private readonly TwitchHttpClient _http;

    public Bits(TwitchHttpClient http)
    {
        _http = http;
    }

    public Task<TwitchDatedResponse<GetBitsLeaderboardResponse>> GetBitsLeaderboardAsync(GetBitsLeaderboardRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("bits/leaderboard")
            .AddParameter("count", request.Count)
            .AddParameter("period", request.Period?.ToString().ToLowerInvariant())
            .AddParameter("started_at", request.StartedAt?.ToRfc3339String())
            .AddParameter("user_id", request.UserId)
            .Build();

        return _http.GetDatedAsync<GetBitsLeaderboardResponse>(url, cancellationToken);
    }
}
