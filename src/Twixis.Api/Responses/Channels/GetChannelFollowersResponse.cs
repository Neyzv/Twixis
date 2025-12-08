// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Responses.Channels;

public sealed record GetChannelFollowersResponse(
    [property: JsonPropertyName("followed_at"), JsonConverter(typeof(JsonUnixDateTimeConverter))] DateTime FollowedAt,
    [property: JsonPropertyName("user_id")] string UserId,
    [property: JsonPropertyName("user_login")] string UserLogin,
    [property: JsonPropertyName("user_name")] string UserName
);
