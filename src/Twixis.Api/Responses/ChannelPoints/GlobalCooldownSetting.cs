// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Responses.ChannelPoints;

public sealed record GlobalCooldownSetting(
    [property: JsonPropertyName("is_enabled")] bool IsEnabled,
    [property: JsonPropertyName("global_cooldown_seconds")] long GlobalCooldownSeconds
);
