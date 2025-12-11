// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

namespace Twixis.Api.Requests.ChannelPoints;

public sealed record GetCustomRewardRequest(
    string BroadcasterId,
    string[]? Ids = null,
    bool? OnlyManageableRewards = null
);
