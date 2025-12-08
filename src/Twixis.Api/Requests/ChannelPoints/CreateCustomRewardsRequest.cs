// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;

namespace Twixis.Api.Requests.ChannelPoints;

public sealed record CreateCustomRewardsRequest(
    [property: JsonIgnore] string BroadcasterId,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("cost")] long Cost,
    [property: JsonPropertyName("prompt")] string? Prompt = null,
    [property: JsonPropertyName("is_enabled")] bool? IsEnabled = null,
    [property: JsonPropertyName("background_color")] string? BackgroundColor = null,
    [property: JsonPropertyName("is_user_input_required")] bool? IsUserInputRequired = null,
    [property: JsonPropertyName("is_max_per_stream_enabled")] bool? IsMaxPerStreamEnabled = null,
    [property: JsonPropertyName("max_per_stream")] int? MaxPerStream = null,
    [property: JsonPropertyName("is_max_per_user_per_stream_enabled")] bool? IsMaxPerUserPerStreamEnabled = null,
    [property: JsonPropertyName("max_per_user_per_stream")] int? MaxPerUserPerStream = null,
    [property: JsonPropertyName("is_global_cooldown_enabled")] bool? IsGlobalCooldownEnabled = null,
    [property: JsonPropertyName("global_cooldown_seconds")] int? GlobalCooldownSeconds = null,
    [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool? ShouldRedemptionsSkipRequestQueue = null
) : TwitchRequest;
