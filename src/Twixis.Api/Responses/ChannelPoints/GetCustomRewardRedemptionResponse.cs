// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Enums;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Responses.ChannelPoints;

public sealed record GetCustomRewardRedemptionResponse(
    [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
    [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
    [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("user_login")] string UserLogin,
    [property: JsonPropertyName("user_name")] string UserName,
    [property: JsonPropertyName("user_input")] string UserInput,
    [property: JsonPropertyName("status"), JsonConverter(typeof(EnumToNameConverter<RedemptionStatus>))] RedemptionStatus RedemptionStatus,
    [property: JsonPropertyName("redeemed_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime RedeemedAt,
    [property: JsonPropertyName("reward")] RedeemedReward Reward
);
