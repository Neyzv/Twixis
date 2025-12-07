// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Responses.Ads;

public sealed record SnoozeNextAdResponse(
    [property: JsonPropertyName("snooze_count")] int SnoozeCount,
    [property: JsonPropertyName("snooze_refresh_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime SnoozeRefreshAt,
    [property: JsonPropertyName("next_ad_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime NextAdAt
);
