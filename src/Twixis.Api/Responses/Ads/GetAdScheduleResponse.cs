// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Responses.Ads;

public sealed record GetAdScheduleResponse(
    [property: JsonPropertyName("snooze_count")] int SnoozeCount,
    [property: JsonPropertyName("snooze_snooze_refresh_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime SnoozeRefreshAt,
    [property: JsonPropertyName("next_ad_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime NextAdAt,
    [property: JsonPropertyName("duration")] int Duration,
    [property: JsonPropertyName("last_ad_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime LasAdAt,
    [property: JsonPropertyName("preroll_free_time")] int PrerollFreeTime
);
