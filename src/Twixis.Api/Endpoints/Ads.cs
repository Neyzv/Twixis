// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Internal.Http;
using Twixis.Api.Internal.Http.Uri;
using Twixis.Api.Requests.Ads;
using Twixis.Api.Responses.Ads;

namespace Twixis.Api.Endpoints;

public sealed class Ads
{
    private readonly TwitchHttpClient _http;

    public Ads(TwitchHttpClient http)
    {
        _http = http;
    }

    public async Task<StartCommercialResponse[]> StartCommercialAsync(StartCommercialRequest request, CancellationToken cancellationToken)
    {
        return (await _http.PostAsync<StartCommercialRequest, StartCommercialResponse>("channels/commercial", request, cancellationToken).ConfigureAwait(false)).Data;
    }

    public async Task<GetAdScheduleResponse[]> GetAdScheduleAsync(GetAdScheduleRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("channels/ads")
            .AddParameter("broadcaster_id", request.BroadcasterId)
            .Build();

        return (await _http.GetAsync<GetAdScheduleResponse>(url, cancellationToken).ConfigureAwait(false)).Data;
    }

    public async Task<SnoozeNextAdResponse[]> SnoozeNextAdAsync(SnoozeNextAdRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("channels/ads/schedule/snooze")
            .AddParameter("broadcaster_id", request.BroadcasterId)
            .Build();

        return (await _http.PostAsync<SnoozeNextAdResponse>(url, cancellationToken).ConfigureAwait(false)).Data;
    }
}
