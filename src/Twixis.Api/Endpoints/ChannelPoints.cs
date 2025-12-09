// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Internal.Http;
using Twixis.Api.Internal.Http.Uri;
using Twixis.Api.Requests.ChannelPoints;
using Twixis.Api.Responses.ChannelPoints;

namespace Twixis.Api.Endpoints;

public sealed class ChannelPoints
{
    private readonly TwitchHttpClient _http;

    public ChannelPoints(TwitchHttpClient http)
    {
        _http = http;
    }

    public async Task<CreateCustomRewardsResponse[]> CreateCustomRewardsAsync(CreateCustomRewardsRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("channel_points/custom_rewards")
            .AddParameter("broadcaster_id", request.BroadcasterId)
            .Build();

        return (await _http.SendRequestAsync<CreateCustomRewardsRequest, CreateCustomRewardsResponse>(HttpMethod.Post, url, request, cancellationToken).ConfigureAwait(false)).Data;
    }

    public Task DeleteCustomRewardAsync(DeleteCustomRewardRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("channel_points/custom_rewards")
            .AddParameter("broadcaster_id", request.BroadcasterId)
            .AddParameter("id", request.Id)
            .Build();

        return _http.SendRequestAsync(HttpMethod.Delete, url, cancellationToken);
    }

    public async Task<GetCustomRewardResponse[]> GetCustomRewardAsync(GetCustomRewardRequest request, CancellationToken cancellationToken)
    {
        var url = UrlBuilder
            .Create("channel_points/custom_rewards")
            .AddParameter("broadcaster_id", request.BroadcasterId)
            .AddParameter("id", request.Id)
            .AddParameter("only_manageable_rewards", request.OnlyManageableRewards)
            .Build();

        return (await _http.SendRequestAsync<GetCustomRewardResponse>(HttpMethod.Post, url, cancellationToken).ConfigureAwait(false)).Data;
    }
}
