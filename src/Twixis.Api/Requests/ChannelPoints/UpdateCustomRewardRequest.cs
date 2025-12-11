// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Requests.ChannelPoints;

public sealed record UpdateCustomRewardRequest(
    [property: JsonIgnore] string BroadcasterId,
    [property: JsonIgnore] string Id,
    [property: JsonPropertyName("title")] string? Title = null,
    [property: JsonPropertyName("prompt")] string? Prompt = null,
    [property: JsonPropertyName("cost")] long? Cost = null,
    [property: JsonPropertyName("background_color")] string? BackgroundColor = null,
    [property: JsonPropertyName("is_enabled")] bool? IsEnabled = null,
    [property: JsonPropertyName("is_user_input_required")] bool? IsUserInputRequired = null,
    [property: JsonPropertyName("is_max_per_stream_enabled")] bool? IsMaxPerStreamEnabled = null,
    [property: JsonPropertyName("max_per_stream")] long? MaxPerStream = null,
    [property: JsonPropertyName("is_max_per_user_per_stream_enabled")] bool? IsMaxPerUserPerStreamEnabled = null,
    [property: JsonPropertyName("max_per_user_per_stream")] long? MaxPerUserPerStream = null,
    [property: JsonPropertyName("is_global_cooldown_enabled")] bool? IsGlobalCooldownEnabled = null,
    [property: JsonPropertyName("global_cooldown_seconds")] long? GlobalCooldownSeconds = null,
    [property: JsonPropertyName("is_paused")] bool? IsPaused = null,
    [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool? ShouldRedemptionsSkipRequestQueue = null
) : TwitchRequest;
