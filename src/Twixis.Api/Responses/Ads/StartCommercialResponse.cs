// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Enums;

namespace Twixis.Api.Responses.Ads;

public sealed record StartCommercialResponse(
    [property: JsonPropertyName("length"), JsonConverter(typeof(JsonNumberEnumConverter<CommercialLength>))] CommercialLength Length,
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("retry_after")] int RetryAfter
);
