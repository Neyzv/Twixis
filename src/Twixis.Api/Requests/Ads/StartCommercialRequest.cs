// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Enums;

namespace Twixis.Api.Requests.Ads;

public sealed record StartCommercialRequest(
    [property: JsonPropertyName("broadcaster_id")] string BroadcasterId,
    [property: JsonPropertyName("length"), JsonConverter(typeof(JsonNumberEnumConverter<CommercialLength>))] CommercialLength Length
) : TwitchRequest;
