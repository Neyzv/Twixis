// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Enums;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Requests.ChannelPoints;

public sealed record UpdateRedemptionStatusRequest(
    [property: JsonIgnore] string[] Ids,
    [property: JsonIgnore] string BroadcasterId,
    [property: JsonIgnore] string RewardId,
    [property: JsonPropertyName("status"), JsonConverter(typeof(EnumToNameConverter<RedemptionStatus>))] RedemptionStatus Status
) : TwitchRequest;
