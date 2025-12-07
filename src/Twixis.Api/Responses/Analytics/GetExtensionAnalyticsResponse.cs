// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Responses.Analytics;

public sealed record GetExtensionAnalyticsResponse(
    [property: JsonPropertyName("extension_id")] string ExtensionId,
    [property: JsonPropertyName("URL")] string Url,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("date_range")] DateRange DateRange
);

