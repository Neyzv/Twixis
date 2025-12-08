// Copyright (c) Twixis 2025.
// Twixis licenses this file to you under the MIT license.
// See the license here https://github.com/AerafalGit/Twixis/blob/main/LICENSE.

using System.Text.Json.Serialization;
using Twixis.Api.Enums;
using Twixis.Api.Internal.Json.Converters;

namespace Twixis.Api.Requests.Channels;

public sealed record ModifyChannelInformationRequest(
    [property: JsonIgnore] string BroadcasterId,
    [property: JsonPropertyName("game_id")] string? GameId = null,
    [property: JsonPropertyName("broadcaster_language")] string? ChannelId = null,
    [property: JsonPropertyName("title")] string? Title = null,
    [property: JsonPropertyName("delay")] ushort? Delay = null,
    [property: JsonPropertyName("tags")] string[]? Tags = null,
    [property: JsonPropertyName("content_classification_labels")] ContentClassificationLabel[]? ContentClassificationLabels = null,
    [property: JsonPropertyName("is_branded_content")] bool? IsBrandedContent = null
) : TwitchRequest;

public sealed record ContentClassificationLabel(
    [property: JsonPropertyName("id"), JsonConverter(typeof(EnumToNameConverter<ContentClassification>))] ContentClassification Id,
    [property: JsonPropertyName("is_enabled")] bool IsEnabled
);
