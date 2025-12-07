// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using Twixis.Api.Enums;

namespace Twixis.Api.Requests.Bits;

public sealed record GetBitsLeaderboardRequest(
    int? Count = null,
    Period? Period = null,
    DateTime? StartedAt = null,
    string? UserId = null
);
