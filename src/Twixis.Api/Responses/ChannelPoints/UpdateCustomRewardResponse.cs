// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Responses.ChannelPoints;

public sealed record UpdateCustomRewardResponse(
    [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
    [property: JsonPropertyName("broadcaster_login")] string BroadcasterLogin,
    [property: JsonPropertyName("broadcaster_name")] string BroadcasterName,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("prompt")] string Prompt,
    [property: JsonPropertyName("cost")] long Cost,
    [property: JsonPropertyName("image")] ImageSet Image,
    [property: JsonPropertyName("default_image")] ImageSet DefaultImage,
    [property: JsonPropertyName("background_color")] string BackgroundColor,
    [property: JsonPropertyName("is_enabled")] bool IsEnabled,
    [property: JsonPropertyName("is_user_input_required")] bool IsUserInputRequired,
    [property: JsonPropertyName("max_per_stream_setting")] MaxPerStreamSetting MaxPerStreamSetting,
    [property: JsonPropertyName("max_per_user_per_stream_setting")] MaxPerUserPerStreamSetting MaxPerUserPerStreamSetting,
    [property: JsonPropertyName("global_cooldown_setting")] GlobalCooldownSetting GlobalCooldownSetting,
    [property: JsonPropertyName("is_paused")] bool IsPaused,
    [property: JsonPropertyName("is_in_stock")] bool IsInStock,
    [property: JsonPropertyName("should_redemptions_skip_request_queue")] bool ShouldRedemptionsSkipRequestQueue,
    [property: JsonPropertyName("redemptions_redeemed_current_stream")] int? RedemptionsRedeemedCurrentStream,
    [property: JsonPropertyName("cooldown_expires_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime? CooldownExpiresAt
);
