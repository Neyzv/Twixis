// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

namespace Twixis.Api.Requests.Analytics;

public sealed record GetGameAnalyticsRequest(
    string? GameId = null,
    string? Type = null,
    DateTime? StartedAt = null,
    DateTime? EndedAt = null,
    byte? First = null,
    string? After = null
);
