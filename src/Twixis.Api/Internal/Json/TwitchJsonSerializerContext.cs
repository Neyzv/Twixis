// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Twixis.Api.Requests.Ads;
using Twixis.Api.Requests.ChannelPoints;
using Twixis.Api.Requests.Channels;
using Twixis.Api.Responses;
using Twixis.Api.Responses.Ads;
using Twixis.Api.Responses.Analytics;
using Twixis.Api.Responses.Bits;
using Twixis.Api.Responses.ChannelPoints;
using Twixis.Api.Responses.Channels;

namespace Twixis.Api.Internal.Json;

[JsonSerializable(typeof(ErrorResponse))]
[JsonSerializable(typeof(StartCommercialRequest))]
[JsonSerializable(typeof(ModifyChannelInformationRequest))]
[JsonSerializable(typeof(CreateCustomRewardsRequest))]
[JsonSerializable(typeof(TwitchResponse<StartCommercialResponse>))]
[JsonSerializable(typeof(TwitchResponse<GetAdScheduleResponse>))]
[JsonSerializable(typeof(TwitchResponse<SnoozeNextAdResponse>))]
[JsonSerializable(typeof(TwitchResponse<GetChannelInformationResponse>))]
[JsonSerializable(typeof(TwitchResponse<GetChannelEditorsResponse>))]
[JsonSerializable(typeof(TwitchResponse<CreateCustomRewardsResponse>))]
[JsonSerializable(typeof(TwitchResponse<GetCustomRewardResponse>))]
[JsonSerializable(typeof(TwitchResponse<GetCustomRewardRedemptionResponse>))]
[JsonSerializable(typeof(TwitchPaginatedResponse<GetExtensionAnalyticsResponse>))]
[JsonSerializable(typeof(TwitchPaginatedResponse<GetGameAnalyticsResponse>))]
[JsonSerializable(typeof(TwitchPaginatedWithTotalResponse<GetFollowedChannelsResponse>))]
[JsonSerializable(typeof(TwitchPaginatedWithTotalResponse<GetChannelFollowersResponse>))]
[JsonSerializable(typeof(TwitchDatedResponse<GetBitsLeaderboardResponse>))]
public sealed partial class TwitchJsonSerializerContext : JsonSerializerContext
{
    public JsonTypeInfo<TJsonTypeInfo> GetTypeInfo<TJsonTypeInfo>()
        where TJsonTypeInfo : class
    {
        if (!Options.TryGetTypeInfo(typeof(TJsonTypeInfo), out var typeInfo))
            throw new InvalidOperationException($"The type '{typeof(TJsonTypeInfo)}' is not supported by this serializer context.");

        if (typeInfo is not JsonTypeInfo<TJsonTypeInfo> typedTypeInfo)
            throw new InvalidOperationException($"The type '{typeof(TJsonTypeInfo)}' is not of the expected type.");

        return typedTypeInfo;
    }
}
