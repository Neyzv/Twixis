// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Internal.Http;
using Twixis.Api.Internal.Http.Uri;
using Twixis.Api.Requests.Channels;
using Twixis.Api.Responses.Ads;
using Twixis.Api.Responses.Channels;

namespace Twixis.Api.Endpoints;

public sealed class Channels
{
    private readonly TwitchHttpClient _http;

    public Channels(TwitchHttpClient http)
    {
        _http = http;
    }

    public async Task<GetChannelInformationResponse[]> GetAdScheduleAsync(GetChannelInformationRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("channels")
            .AddParameter("broadcaster_id", request.BroadcasterId)
            .Build();

        return (await _http.GetAsync<GetChannelInformationResponse>(url, cancellationToken).ConfigureAwait(false)).Data;
    }
}
