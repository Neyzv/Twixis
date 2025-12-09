// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Enums;

namespace Twixis.Api.Requests.ChannelPoints;

public sealed record GetCustomRewardRedemptionRequest(
    string BroadcasterId,
    string RewardId,
    RedemptionStatus Status,
    string[]? Ids = null,
    RedemptionSort? Sort = null,
    string? After = null,
    int? First = null
);
